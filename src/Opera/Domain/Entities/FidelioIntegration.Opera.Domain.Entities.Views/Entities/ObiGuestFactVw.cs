namespace FidelioIntegration.Opera.Domain.Entities.Views;

public partial class ObiGuestFactVw
{
    public string? NameId { get; set; }
    public string? Resort { get; set; }
    public DateTime? BusinessDate { get; set; }
    public string? MarketCode { get; set; }
    public string? SourceCode { get; set; }
    public string? RoomType { get; set; }
    public string? PromotionCode { get; set; }
    public decimal? TotalRevenue { get; set; }
    public decimal? RoomRevenue { get; set; }
    public decimal? FbRevenue { get; set; }
    public decimal? OtherRevenue { get; set; }
    public decimal? NonRevenue { get; set; }
    public decimal? Nights { get; set; }
    public decimal? StayRooms { get; set; }
    public decimal? NoOfStays { get; set; }
    public decimal? LeadDays { get; set; }
    public decimal? LeadCount { get; set; }
    public decimal? DayUseReservations { get; set; }
    public decimal? CancelledReservations { get; set; }
    public decimal? NoShowReservations { get; set; }
    public decimal? CTotalRevenue { get; set; }
    public decimal? CRoomRevenue { get; set; }
    public decimal? CFbRevenue { get; set; }
    public decimal? COtherRevenue { get; set; }
    public decimal? CNonRevenue { get; set; }
    public decimal? Rcnt { get; set; }

	public static void OnModelCreating(ModelBuilder modelBuilder, ISet<Type> types)
	{
		modelBuilder.Entity<ObiGuestFactVw>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("OBI_GUEST_FACT_VW");

            entity.Property(e => e.BusinessDate)
                .HasColumnName("BUSINESS_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.CFbRevenue)
                .HasColumnName("C_FB_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.CNonRevenue)
                .HasColumnName("C_NON_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.COtherRevenue)
                .HasColumnName("C_OTHER_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.CRoomRevenue)
                .HasColumnName("C_ROOM_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.CTotalRevenue)
                .HasColumnName("C_TOTAL_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.CancelledReservations)
                .HasColumnName("CANCELLED_RESERVATIONS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.DayUseReservations)
                .HasColumnName("DAY_USE_RESERVATIONS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.FbRevenue)
                .HasColumnName("FB_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.LeadCount)
                .HasColumnName("LEAD_COUNT")
                .HasColumnType("NUMBER");

            entity.Property(e => e.LeadDays)
                .HasColumnName("LEAD_DAYS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.MarketCode)
                .HasColumnName("MARKET_CODE")
                .IsUnicode(false);

            entity.Property(e => e.NameId)
                .HasColumnName("NAME_ID")
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.Property(e => e.Nights)
                .HasColumnName("NIGHTS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.NoOfStays)
                .HasColumnName("NO_OF_STAYS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.NoShowReservations)
                .HasColumnName("NO_SHOW_RESERVATIONS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.NonRevenue)
                .HasColumnName("NON_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.OtherRevenue)
                .HasColumnName("OTHER_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.PromotionCode)
                .HasColumnName("PROMOTION_CODE")
                .IsUnicode(false);

            entity.Property(e => e.Rcnt)
                .HasColumnName("RCNT")
                .HasColumnType("NUMBER");

            entity.Property(e => e.Resort)
                .HasColumnName("RESORT")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.RoomRevenue)
                .HasColumnName("ROOM_REVENUE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.RoomType)
                .HasColumnName("ROOM_TYPE")
                .IsUnicode(false);

            entity.Property(e => e.SourceCode)
                .HasColumnName("SOURCE_CODE")
                .IsUnicode(false);

            entity.Property(e => e.StayRooms)
                .HasColumnName("STAY_ROOMS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.TotalRevenue)
                .HasColumnName("TOTAL_REVENUE")
                .HasColumnType("NUMBER");
        });
	}
}
