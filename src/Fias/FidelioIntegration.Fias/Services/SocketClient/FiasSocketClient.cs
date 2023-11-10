namespace FidelioIntegration.Fias.SocketClient;

internal class FiasSocketClient : BackgroundService
{
    private const char HEAD = FiasEnviroments.HEAD;

    private const char TAIL = FiasEnviroments.TAIL;

    private readonly string _separator = $"{TAIL}{HEAD}";

    private readonly IFiasService _fiasService;

    private NetworkStream? _stream;

    private string? _lastError;

    public FiasSocketClient(IFiasService fiasService)
    {
        _fiasService = fiasService;
        _fiasService.FiasSendMessageEvent += SendAsync;
    }

    protected sealed override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
            await Task.Run(ConnectAsync);
    }

    private async Task ConnectAsync()
    {
        if (_fiasService.CancellationToken.IsCancellationRequested)
        {
            _fiasService.RefreshCancellationToken();
            await Task.Delay(6000);
        }

        if (!_fiasService.IsRunning)
            return;

        if (_fiasService.CancellationToken.IsCancellationRequested)
            return;

        using TcpClient tcpClient = new();
        if (!ConnectToFias(tcpClient))
            return;

        if (_fiasService.CancellationToken.IsCancellationRequested)
            return;

        _fiasService.ChangeConnectionStateEventInvoke(true, _fiasService.Hostname, _fiasService.Port);

        StringBuilder stringBuilder = new();

        try
        {
            using NetworkStream stream = tcpClient.GetStream();
            _stream = stream;
            while (true)
            {
                await Task.Run(async () => await ReadAsync(stream, stringBuilder));

                if (_fiasService.CancellationToken.IsCancellationRequested)
                    break;
            }
        }
        catch (Exception ex)
        {
            _stream = null;
            _fiasService.ErrorEventInvoke(ex.Message, ex);
            _fiasService.ChangeConnectionStateEventInvoke(false);
        }
    }

    private async Task ReadAsync(NetworkStream stream, StringBuilder stringBuilder)
    {
        var buffer = new byte[8192];
        try
        {
            var size = await stream.ReadAsync(buffer, 0, buffer.Length, _fiasService.CancellationToken);

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
        }
        catch (OperationCanceledException)
        {
            _stream = null;
            _fiasService.ChangeConnectionStateEventInvoke(false);
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

    private Task SendAsync(string message)
    {
        if (message is null)
            throw new ArgumentException("The message was not sent because it is null.");

        if (_stream is null)
            throw new InvalidOperationException("The message was not sent because the connection to FIAS was not established.");

        try
        {
            _stream.Write(Encoding.Default.GetBytes(message));
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    private bool ConnectToFias(TcpClient tcpClient)
    {
        if (_fiasService.CancellationToken.IsCancellationRequested)
            return false;

        if (string.IsNullOrWhiteSpace(_fiasService.Hostname))
        {
            TrySendError("Hostname is null or whitespace");
            return false;
        }

        if (_fiasService.CancellationToken.IsCancellationRequested)
            return false;

        if (_fiasService.Port < IPEndPoint.MinPort || _fiasService.Port > IPEndPoint.MaxPort)
        {
            TrySendError($"Port {_fiasService.Port} out of range [{IPEndPoint.MinPort}..{IPEndPoint.MaxPort}]");
            return false;
        }

        if (_fiasService.CancellationToken.IsCancellationRequested)
            return false;

        try
        {
            if (!tcpClient.ConnectAsync(_fiasService.Hostname!, _fiasService.Port).Wait(1000, _fiasService.CancellationToken))
            {
                TrySendError($"The remote host {_fiasService.Hostname}:{_fiasService.Port} was not found.");
                return false;
            }

            _lastError = null;
            return true;
        }
        catch (OperationCanceledException)
        {
            return false;
        }
        catch (AggregateException)
        {
            TrySendError($"Failed to connect to remote host {_fiasService.Hostname}:{_fiasService.Port}");
            return false;
        }
        catch (Exception ex)
        {
            TrySendError(ex.Message, ex);
            return false;
        }
    }

    private void TrySendError(string message, Exception? ex = null)
    {
        if (_lastError == null || _lastError != message)
        {
            _lastError = message;
            _fiasService.ErrorEventInvoke(message, ex);
        }
    }

    private static string FixHead(string message, StringBuilder stringBuilder)
        => message[0] != HEAD ? stringBuilder.Append(message[..^1]).ToString() : message[1..^1];
}

