namespace FidelioIntegration.Fias.Services.ConnectionService;

internal class FiasConnectionService : IFiasConnectionService
{
    private bool _isRunning;

    private string? _hostname;

    private int _port;

    private CancellationTokenSource? _cancelTokenSource;

    public bool IsRunning
    {
        get => _isRunning;

        set
        {
            if (value != _isRunning)
            {
                _isRunning = value;
                _cancelTokenSource?.Cancel();
            }
        }
    }

    public string? Hostname
    {
        get => _hostname;

        set
        {
            if (value != _hostname)
            {
                _hostname = value;
                _cancelTokenSource?.Cancel();
            }
        }
    }

    public int Port
    {
        get => _port;

        set
        {
            if (value != _port)
            {
                _port = value;
                _cancelTokenSource?.Cancel();
            }
        }
    }

    public CancellationToken CancellationToken { get; private set; }

    public FiasConnectionService()
    {
        RefreshCancellationToken();
    }

    public FiasConnectionService(IOptions<FiasDefaultConnectionOptions> options)
    {
        var defaultOptions = options.Value;
        _hostname = defaultOptions.DefaultHostname;
        _port = defaultOptions.DefaultPort;
        _isRunning = defaultOptions.DefaultRunning;
        RefreshCancellationToken();
    }

    public void RefreshCancellationToken()
    {
        _cancelTokenSource = new CancellationTokenSource();
        CancellationToken = _cancelTokenSource.Token;
    }
}

