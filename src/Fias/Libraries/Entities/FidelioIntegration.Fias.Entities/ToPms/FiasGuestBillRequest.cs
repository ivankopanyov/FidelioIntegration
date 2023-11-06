﻿namespace FidelioIntegration.Fias.Entities;

/// <summary>
/// To send <see cref="FiasGuestBillRequest"/> to FIAS, send an instance of
/// <see cref="FiasLinkRecord"/> to FIAS with an instance of
/// <see cref="FiasGuestBillRequestOptions"/> passed to the constructor.<br/>
/// Чтобы отправить <see cref="FiasGuestBillRequest"/> в FIAS, отправьте экземпляр
/// <see cref="FiasLinkRecord"/> в FIAS с переданным в конструктор экземпляром
/// <see cref="FiasGuestBillRequestOptions"/>.
/// </summary>
public partial class FiasGuestBillRequest : FiasMessageToPms
{
    /// <summary>
    /// <b>Required.</b><br/>
    /// Valid values ​​range from <see cref="FiasEnviroments.MIN_10"/> to <see cref="FiasEnviroments.MAX_10"/>.<br/>
    /// <b>Обязательно.</b><br/>
    /// Допустимое значение в диапазоне от <see cref="FiasEnviroments.MIN_10"/> до <see cref="FiasEnviroments.MAX_10"/>.
    /// </summary>
    [Required]
    [Range(FiasEnviroments.MIN_10, FiasEnviroments.MAX_10)]
    public long ReservationNumber { get; set; }

    /// <summary>
    /// <b>Required.</b><br/>
    /// Max length is 8. Can be longer with Suite8 or OPERA PMS.<br/>
    /// <b>Обязательно.</b><br/>
    /// Максимальная длина = 8. Может быть длиннее с Suite8 или OPERA PMS.
    /// </summary>
    [Required]
    public string RoomNumber { get; set; }

    public DateTime? DateTime { get; set; }
}

