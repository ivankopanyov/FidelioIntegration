namespace FidelioIntegration.Fias.SocketClient;

internal class FiasSocketClient : BackgroundService
{
    private const char HEAD = FiasEnviroments.HEAD;

    private const char TAIL = FiasEnviroments.TAIL;

    private readonly string _separator = $"{TAIL}{HEAD}";

    private readonly IFiasConnectionService _connection;

    private readonly IFiasService _fiasService;

    private NetworkStream? _stream;

    private string? _lastError;

    public FiasSocketClient(IFiasConnectionService fiasConnectionService, IFiasService fiasService)
    {
        _connection = fiasConnectionService;
        _fiasService = fiasService;
        _fiasService.SendMessageEvent += Send;
    }

    protected sealed override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            if (_connection.CancellationToken.IsCancellationRequested)
                _connection.RefreshCancellationToken();

            if (!_connection.IsRunning)
                continue;

            if (GetTcpClient() is not TcpClient tcpClient)
                continue;

            ChangeStateHandle(true);

            StringBuilder stringBuilder = new();

            try
            {
                using NetworkStream stream = tcpClient.GetStream();
                _stream = stream;
                while (true)
                {
                    var buffer = new byte[8192];
                    var size = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (size > 0)
                    {
                        if (size < buffer.Length)
                            Array.Resize(ref buffer, size);

                        var temp = Encoding.Default.GetString(buffer, 0, size);
                        var messages = temp.Split(_separator);

                        if (messages.Length == 1 && messages[0].Length > 0)
                        {
                            if (messages[0][^1] != TAIL)
                            {
                                if (messages[0][0] != HEAD)
                                    stringBuilder.Append(messages[0]);
                                else
                                    stringBuilder.Clear().Append(messages[0][1..]);
                            }
                            else
                            {
                                var message = FixHead(messages[0], stringBuilder);
                                MessageHandle(message);
                                stringBuilder.Clear();
                            }
                        }
                        else if (messages.Length > 1)
                        {
                            var message = messages[0].Length != 0 ? FixHead(messages[0], stringBuilder) : stringBuilder.ToString();
                            MessageHandle(message);
                            stringBuilder.Clear();

                            for (int i = 1; i < messages.Length - 1; i++)
                                MessageHandle(messages[i]);

                            message = messages[^1];

                            if (message.Length != 0)
                            {
                                if (message[^1] != TAIL)
                                    stringBuilder.Append(message);
                                else
                                    MessageHandle(message[..^1]);
                            }
                        }
                    }

                    if (_connection.CancellationToken.IsCancellationRequested)
                    {
                        _stream = null;
                        tcpClient.Close();
                        ChangeStateHandle(false);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _stream = null;
                tcpClient.Close();
                ErrorFromPmsHandle(ex.Message);
                ChangeStateHandle(false);
            }
        }
    }

    private void MessageHandle(string message)
    {
        var commonMessage = FiasCommonMessage.FromString(message);

        if (commonMessage.ToFiasMessageFromPmsObject() is object fiasMessage)
            _fiasService.MessageEventInvoke(fiasMessage);
        else
            _fiasService.UnknownTypeMessageEventInvoke(commonMessage);
    }

    private void ErrorFromPmsHandle(string errorMessage) => _fiasService.ErrorFromPmsMessageEventInvoke(errorMessage);

    private void ErrorToPmsHandle(string errorMessage) => _fiasService.ErrorToPmsMessageEventInvoke(errorMessage);

    private void ChangeStateHandle(bool isConnected) => _fiasService.ChangeStateEventInvoke(isConnected);

    private void Send(string message)
    {
        if (message is null)
        {
            ErrorToPmsHandle("The message was not sent because it is null.");
            return;
        }

        if (_stream is null)
        {
            ErrorToPmsHandle("The message was not sent because the connection to FIAS was not established.");
            return;
        }

        try
        {
            _stream.Write(Encoding.Default.GetBytes(message));
        }
        catch (Exception ex)
        {
            ErrorToPmsHandle(ex.Message);
        }
    }

    private TcpClient? GetTcpClient()
    {
        string errorMessage;

        if (string.IsNullOrWhiteSpace(_connection.Hostname))
            errorMessage = "Hostname is null or whitespace";
        else if (_connection.Port < IPEndPoint.MinPort || _connection.Port > IPEndPoint.MaxPort)
            errorMessage = $"Port {_connection.Port} out of range [{IPEndPoint.MinPort}..{IPEndPoint.MaxPort}]";
        else
        {

            TcpClient tcpClient;
            try
            {
                tcpClient = new();
                tcpClient.Connect(_connection.Hostname, _connection.Port);
                _lastError = null;
                return tcpClient;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        if (_lastError == null || _lastError != errorMessage)
        {
            _lastError = errorMessage;
            ErrorFromPmsHandle(errorMessage);
        }

        return null;
    }

    private static string FixHead(string message, StringBuilder stringBuilder)
        => message[0] != HEAD ? stringBuilder.Append(message[..^1]).ToString() : message[1..^1];
}

