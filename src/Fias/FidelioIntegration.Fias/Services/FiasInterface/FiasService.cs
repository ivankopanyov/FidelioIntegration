namespace FidelioIntegration.Fias.Services.FiasInterface;

internal class FiasService : IFiasService
{
    #region Events

    public event FiasMessageHandle<FiasLinkStart>? FiasLinkStartEvent;
    public event FiasMessageHandle<FiasLinkAlive>? FiasLinkAliveEvent;
    public event FiasMessageHandle<FiasLinkEnd>? FiasLinkEndEvent;
    public event FiasMessageHandle<FiasMessageDelete>? FiasMessageDeleteEvent;
    public event FiasMessageHandle<FiasWakeupClear>? FiasWakeupClearEvent;
    public event FiasMessageHandle<FiasWakeupRequest>? FiasWakeupRequestEvent;
    public event FiasMessageHandle<FiasDatabaseResyncEnd>? FiasDatabaseResyncEndEvent;
    public event FiasMessageHandle<FiasDatabaseResyncStart>? FiasDatabaseResyncStartEvent;
    public event FiasMessageHandle<FiasGuestBillBalance>? FiasGuestBillBalanceEvent;
    public event FiasMessageHandle<FiasGuestBillItem>? FiasGuestBillItemEvent;
    public event FiasMessageHandle<FiasGuestChange>? FiasGuestChangeEvent;
    public event FiasMessageHandle<FiasGuestCheckIn>? FiasGuestCheckInEvent;
    public event FiasMessageHandle<FiasGuestCheckOut>? FiasGuestCheckOutEvent;
    public event FiasMessageHandle<FiasKeyDataChange>? FiasKeyDataChangeEvent;
    public event FiasMessageHandle<FiasKeyDelete>? FiasKeyDeleteEvent;
    public event FiasMessageHandle<FiasKeyReadResponse>? FiasKeyReadResponseEvent;
    public event FiasMessageHandle<FiasKeyRequest>? FiasKeyRequestEvent;
    public event FiasMessageHandle<FiasLinkConfiguration>? FiasLinkConfigurationEvent;
    public event FiasMessageHandle<FiasLocatorRetrieveResponse>? FiasLocatorRetrieveResponseEvent;
    public event FiasMessageHandle<FiasMessageText>? FiasMessageTextEvent;
    public event FiasMessageHandle<FiasMessageTextOnlineResponse>? FiasMessageTextOnlineResponseEvent;
    public event FiasMessageHandle<FiasNightAuditEnd>? FiasNightAuditEndEvent;
    public event FiasMessageHandle<FiasNightAuditStart>? FiasNightAuditStartEvent;
    public event FiasMessageHandle<FiasPostingAnswer>? FiasPostingAnswerEvent;
    public event FiasMessageHandle<FiasPostingList>? FiasPostingListEvent;
    public event FiasMessageHandle<FiasRemoteCheckOutResponse>? FiasRemoteCheckOutResponseEvent;
    public event FiasMessageHandle<FiasRoomEquipmentStatusResponse>? FiasRoomEquipmentStatusResponseEvent;
    public event FiasMessageHandle<FiasCommonMessage>? UnknownTypeMessageEvent;
    public event FiasMessageHandle<FiasCommonMessage>? FiasUnknownTypeMessageEvent;

    public event FiasErrorHandle? FiasErrorEvent;

    public event FiasChangeConnectionStateHandle? FiasChangeConnectionStateEvent;

    public event FiasSendMessageHandle? FiasSendMessageEvent;

    #endregion

    private bool _isRunning;

    private string? _hostname;

    private int _port;

    private CancellationTokenSource _cancellationTokenSource;

    private CancellationToken _cancellationToken;

    public bool IsRunning
    {
        get => _isRunning;

        set
        {
            if (value != _isRunning)
            {
                _isRunning = value;
                _cancellationTokenSource.Cancel();
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
                _cancellationTokenSource.Cancel();
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
                _cancellationTokenSource.Cancel();
            }
        }
    }

    public CancellationToken CancellationToken => _cancellationToken;

    public FiasService() => RefreshCancellationToken();

    public FiasService(IOptions<FiasDefaultConnectionOptions> options) : this()
    {
        var defaultOptions = options.Value;
        _hostname = defaultOptions.DefaultHostname;
        _port = defaultOptions.DefaultPort;
        _isRunning = defaultOptions.DefaultRunning;
    }

    public void RefreshCancellationToken()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
    }

    public void Send(string message) => FiasSendMessageEvent?.Invoke(message);

    public void MessageEventInvoke(object message)
    {
        switch (message)
        {
            case FiasLinkStart:
                FiasLinkStartEvent?.Invoke((FiasLinkStart)message);
                break;
            case FiasLinkAlive:
                FiasLinkAliveEvent?.Invoke((FiasLinkAlive)message);
                break;
            case FiasLinkEnd:
                FiasLinkEndEvent?.Invoke((FiasLinkEnd)message);
                break;
            case FiasMessageDelete:
                FiasMessageDeleteEvent?.Invoke((FiasMessageDelete)message);
                break;
            case FiasWakeupClear:
                FiasWakeupClearEvent?.Invoke((FiasWakeupClear)message);
                break;
            case FiasWakeupRequest:
                FiasWakeupRequestEvent?.Invoke((FiasWakeupRequest)message);
                break;
            case FiasDatabaseResyncEnd:
                FiasDatabaseResyncEndEvent?.Invoke((FiasDatabaseResyncEnd)message);
                break;
            case FiasDatabaseResyncStart:
                FiasDatabaseResyncStartEvent?.Invoke((FiasDatabaseResyncStart)message);
                break;
            case FiasGuestBillBalance:
                FiasGuestBillBalanceEvent?.Invoke((FiasGuestBillBalance)message);
                break;
            case FiasGuestBillItem:
                FiasGuestBillItemEvent?.Invoke((FiasGuestBillItem)message);
                break;
            case FiasGuestChange:
                FiasGuestChangeEvent?.Invoke((FiasGuestChange)message);
                break;
            case FiasGuestCheckIn:
                FiasGuestCheckInEvent?.Invoke((FiasGuestCheckIn)message);
                break;
            case FiasGuestCheckOut:
                FiasGuestCheckOutEvent?.Invoke((FiasGuestCheckOut)message);
                break;
            case FiasKeyDataChange:
                FiasKeyDataChangeEvent?.Invoke((FiasKeyDataChange)message);
                break;
            case FiasKeyDelete:
                FiasKeyDeleteEvent?.Invoke((FiasKeyDelete)message);
                break;
            case FiasKeyReadResponse:
                FiasKeyReadResponseEvent?.Invoke((FiasKeyReadResponse)message);
                break;
            case FiasKeyRequest:
                FiasKeyRequestEvent?.Invoke((FiasKeyRequest)message);
                break;
            case FiasLinkConfiguration:
                FiasLinkConfigurationEvent?.Invoke((FiasLinkConfiguration)message);
                break;
            case FiasLocatorRetrieveResponse:
                FiasLocatorRetrieveResponseEvent?.Invoke((FiasLocatorRetrieveResponse)message);
                break;
            case FiasMessageText:
                FiasMessageTextEvent?.Invoke((FiasMessageText)message);
                break;
            case FiasMessageTextOnlineResponse:
                FiasMessageTextOnlineResponseEvent?.Invoke((FiasMessageTextOnlineResponse)message);
                break;
            case FiasNightAuditEnd:
                FiasNightAuditEndEvent?.Invoke((FiasNightAuditEnd)message);
                break;
            case FiasNightAuditStart:
                FiasNightAuditStartEvent?.Invoke((FiasNightAuditStart)message);
                break;
            case FiasPostingAnswer:
                FiasPostingAnswerEvent?.Invoke((FiasPostingAnswer)message);
                break;
            case FiasPostingList:
                FiasPostingListEvent?.Invoke((FiasPostingList)message);
                break;
            case FiasRemoteCheckOutResponse:
                FiasRemoteCheckOutResponseEvent?.Invoke((FiasRemoteCheckOutResponse)message);
                break;
            case FiasRoomEquipmentStatusResponse:
                FiasRoomEquipmentStatusResponseEvent?.Invoke((FiasRoomEquipmentStatusResponse)message);
                break;
        }
    }

    public void UnknownTypeMessageEventInvoke(FiasCommonMessage message) =>
        UnknownTypeMessageEvent?.Invoke(message);

    public void ErrorEventInvoke(string errorMessage, Exception? ex = null) =>
        FiasErrorEvent?.Invoke(errorMessage, ex);

    public void ChangeConnectionStateEventInvoke(bool isConnected, string? hostname = null, int? port = null) =>
        FiasChangeConnectionStateEvent?.Invoke(isConnected, hostname, port);
}

