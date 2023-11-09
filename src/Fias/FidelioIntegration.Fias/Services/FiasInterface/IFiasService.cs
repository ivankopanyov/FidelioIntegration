namespace FidelioIntegration.Fias;

public delegate void FiasMessageHandle<T>(T message);

public delegate void FiasSendMessage(string message);

public interface IFiasService
{
    event FiasMessageHandle<FiasLinkStart>? FiasLinkStartEvent;
    event FiasMessageHandle<FiasLinkAlive>? FiasLinkAliveEvent;
    event FiasMessageHandle<FiasLinkEnd>? FiasLinkEndEvent;
    event FiasMessageHandle<FiasMessageDelete>? FiasMessageDeleteEvent;
    event FiasMessageHandle<FiasWakeupClear>? FiasWakeupClearEvent;
    event FiasMessageHandle<FiasWakeupRequest>? FiasWakeupRequestEvent;
    event FiasMessageHandle<FiasDatabaseResyncEnd>? FiasDatabaseResyncEndEvent;
    event FiasMessageHandle<FiasDatabaseResyncStart>? FiasDatabaseResyncStartEvent;
    event FiasMessageHandle<FiasGuestBillBalance>? FiasGuestBillBalanceEvent;
    event FiasMessageHandle<FiasGuestBillItem>? FiasGuestBillItemEvent;
    event FiasMessageHandle<FiasGuestChange>? FiasGuestChangeEvent;
    event FiasMessageHandle<FiasGuestCheckIn>? FiasGuestCheckInEvent;
    event FiasMessageHandle<FiasGuestCheckOut>? FiasGuestCheckOutEvent;
    event FiasMessageHandle<FiasKeyDataChange>? FiasKeyDataChangeEvent;
    event FiasMessageHandle<FiasKeyDelete>? FiasKeyDeleteEvent;
    event FiasMessageHandle<FiasKeyReadResponse>? FiasKeyReadResponseEvent;
    event FiasMessageHandle<FiasKeyRequest>? FiasKeyRequestEvent;
    event FiasMessageHandle<FiasLinkConfiguration>? FiasLinkConfigurationEvent;
    event FiasMessageHandle<FiasLocatorRetrieveResponse>? FiasLocatorRetrieveResponseEvent;
    event FiasMessageHandle<FiasMessageText>? FiasMessageTextEvent;
    event FiasMessageHandle<FiasMessageTextOnlineResponse>? FiasMessageTextOnlineResponseEvent;
    event FiasMessageHandle<FiasNightAuditEnd>? FiasNightAuditEndEvent;
    event FiasMessageHandle<FiasNightAuditStart>? FiasNightAuditStartEvent;
    event FiasMessageHandle<FiasPostingAnswer>? FiasPostingAnswerEvent;
    event FiasMessageHandle<FiasPostingList>? FiasPostingListEvent;
    event FiasMessageHandle<FiasRemoteCheckOutResponse>? FiasRemoteCheckOutResponseEvent;
    event FiasMessageHandle<FiasRoomEquipmentStatusResponse>? FiasRoomEquipmentStatusResponseEvent;
    event FiasMessageHandle<FiasCommonMessage>? UnknownTypeMessageEvent;
    event FiasMessageHandle<string>? ErrorFromPmsMessageEvent;
    event FiasMessageHandle<string>? ErrorToPmsMessageEvent;
    event FiasMessageHandle<bool>? ChangeStateEvent;

    internal event FiasSendMessage? SendMessageEvent;

    void Send(string message);

    internal void UnknownTypeMessageEventInvoke(FiasCommonMessage message);

    internal void MessageEventInvoke(object message);

    internal void ErrorFromPmsMessageEventInvoke(string errorMessage);

    internal void ErrorToPmsMessageEventInvoke(string errorMessage);

    internal void ChangeStateEventInvoke(bool isConnected);
}

