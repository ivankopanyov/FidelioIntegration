namespace FidelioIntegration.Opera.Domain.Entities.Views;

public partial class EisMembershipTransactions
{
    public decimal MembershipTrxId { get; set; }
    public string? RecordType { get; set; }
    public string? Resort { get; set; }
    public decimal NameId { get; set; }
    public string? MembershipType { get; set; }
    public string? MembershipCardNo { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? PmsNameId { get; set; }
    public string? PmsResvNo { get; set; }
    public string? PmsResvNameId { get; set; }
    public decimal? StayRecordId { get; set; }
    public string? PopulationMethod { get; set; }
    public decimal? AwardRequestId { get; set; }
    public decimal? AwardOrderNo { get; set; }
    public decimal? Stay { get; set; }
    public decimal? Nights { get; set; }
    public decimal? TotalRevenue { get; set; }
    public string? CurrencyCode { get; set; }
    public string? PromotionCode1 { get; set; }
    public string? PromotionCode2 { get; set; }
    public string? PromotionCode3 { get; set; }
    public decimal? TotalBasePoints { get; set; }
    public decimal? TotalBonusPoints { get; set; }
    public decimal? OldBalancePoints { get; set; }
    public decimal? MembershipBaseNights { get; set; }
    public decimal? MembershipBaseRevenue { get; set; }
    public decimal? MembershipBonusNights { get; set; }
    public decimal? MembershipBonusRevenue { get; set; }
    public decimal? PointsCost { get; set; }
    public DateTime? PointsCreditDate { get; set; }
    public string? PointsCalculatedYn { get; set; }
    public string? ProcessingMessages { get; set; }
    public decimal InsertUser { get; set; }
    public DateTime InsertDate { get; set; }
    public decimal UpdateUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? InactiveDate { get; set; }
    public string? DataExportedYn { get; set; }
    public decimal MembershipId { get; set; }
    public string? MembershipLevel { get; set; }
    public DateTime? MembershipTrxDate { get; set; }
    public DateTime? DataExportedDate { get; set; }
    public decimal? TotalPoints { get; set; }
    public decimal? TotalMiscPoints { get; set; }
    public string? AutomaticYn { get; set; }
    public string? AdjustmentYn { get; set; }
    public decimal? ParentMembershipTrxId { get; set; }

	public static void OnModelCreating(ModelBuilder modelBuilder, ISet<Type> types)
	{
		modelBuilder.Entity<EisMembershipTransactions>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("EIS_MEMBERSHIP_TRANSACTIONS");

            entity.Property(e => e.AdjustmentYn)
                .IsRequired()
                .HasColumnName("ADJUSTMENT_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.AutomaticYn)
                .HasColumnName("AUTOMATIC_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.AwardOrderNo)
                .HasColumnName("AWARD_ORDER_NO")
                .HasColumnType("NUMBER");

            entity.Property(e => e.AwardRequestId)
                .HasColumnName("AWARD_REQUEST_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.BeginDate)
                .HasColumnName("BEGIN_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.CurrencyCode)
                .HasColumnName("CURRENCY_CODE")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.DataExportedDate)
                .HasColumnName("DATA_EXPORTED_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.DataExportedYn)
                .HasColumnName("DATA_EXPORTED_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.EndDate)
                .HasColumnName("END_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.InactiveDate)
                .HasColumnName("INACTIVE_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.InsertDate)
                .HasColumnName("INSERT_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.InsertUser)
                .HasColumnName("INSERT_USER")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MembershipBaseNights)
                .HasColumnName("MEMBERSHIP_BASE_NIGHTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MembershipBaseRevenue)
                .HasColumnName("MEMBERSHIP_BASE_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MembershipBonusNights)
                .HasColumnName("MEMBERSHIP_BONUS_NIGHTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MembershipBonusRevenue)
                .HasColumnName("MEMBERSHIP_BONUS_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MembershipCardNo)
                .IsRequired()
                .HasColumnName("MEMBERSHIP_CARD_NO")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MembershipId)
                .HasColumnName("MEMBERSHIP_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MembershipLevel)
                .HasColumnName("MEMBERSHIP_LEVEL")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.MembershipTrxDate)
                .HasColumnName("MEMBERSHIP_TRX_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.MembershipTrxId)
                .HasColumnName("MEMBERSHIP_TRX_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MembershipType)
                .IsRequired()
                .HasColumnName("MEMBERSHIP_TYPE")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.NameId)
                .HasColumnName("NAME_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.Nights)
                .HasColumnName("NIGHTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.OldBalancePoints)
                .HasColumnName("OLD_BALANCE_POINTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.ParentMembershipTrxId)
                .HasColumnName("PARENT_MEMBERSHIP_TRX_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.PmsNameId)
                .HasColumnName("PMS_NAME_ID")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PmsResvNameId)
                .HasColumnName("PMS_RESV_NAME_ID")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PmsResvNo)
                .HasColumnName("PMS_RESV_NO")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PointsCalculatedYn)
                .IsRequired()
                .HasColumnName("POINTS_CALCULATED_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.PointsCost)
                .HasColumnName("POINTS_COST")
                .HasColumnType("NUMBER");

            entity.Property(e => e.PointsCreditDate)
                .HasColumnName("POINTS_CREDIT_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.PopulationMethod)
                .HasColumnName("POPULATION_METHOD")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.ProcessingMessages)
                .HasColumnName("PROCESSING_MESSAGES")
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.PromotionCode1)
                .HasColumnName("PROMOTION_CODE1")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PromotionCode2)
                .HasColumnName("PROMOTION_CODE2")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PromotionCode3)
                .HasColumnName("PROMOTION_CODE3")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.RecordType)
                .IsRequired()
                .HasColumnName("RECORD_TYPE")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Resort)
                .IsRequired()
                .HasColumnName("RESORT")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Stay)
                .HasColumnName("STAY")
                .HasColumnType("NUMBER");

            entity.Property(e => e.StayRecordId)
                .HasColumnName("STAY_RECORD_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.TotalBasePoints)
                .HasColumnName("TOTAL_BASE_POINTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.TotalBonusPoints)
                .HasColumnName("TOTAL_BONUS_POINTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.TotalMiscPoints)
                .HasColumnName("TOTAL_MISC_POINTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.TotalPoints)
                .HasColumnName("TOTAL_POINTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.TotalRevenue)
                .HasColumnName("TOTAL_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.UpdateDate)
                .HasColumnName("UPDATE_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.UpdateUser)
                .HasColumnName("UPDATE_USER")
                .HasColumnType("NUMBER");
        });
	}
}
