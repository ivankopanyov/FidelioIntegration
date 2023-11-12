namespace FidelioIntegration.Opera.Domain.Entities.Tables;

public partial class CurrencyExchangeRatesJrnl
{
    public DateTime? BeginDate { get; set; }
    public decimal? ExchangeRate { get; set; }
    public string? LockRateYn { get; set; }
    public string? Comments { get; set; }
    public DateTime? InsertDate { get; set; }
    public decimal? InsertUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public decimal? UpdateUser { get; set; }
    public string? Resort { get; set; }
    public string? ExchangeRateType { get; set; }
    public string? BaseCurrCode { get; set; }
    public string? CurrencyCode { get; set; }
    public decimal? CurrActionId { get; set; }
    public decimal? OldCurrActionId { get; set; }
    public decimal? BuyCommPerc { get; set; }
    public decimal? SellCommPerc { get; set; }
    public decimal? SellExchangeRate { get; set; }
    public decimal? BuyForeignExchangeRate { get; set; }
    public decimal? SellForeignExchangeRate { get; set; }
    public DateTime? SystemDate { get; set; }
    public DateTime? JrnlBusinessDate { get; set; }
    public decimal? JrnlUser { get; set; }

	public static void OnModelCreating(ModelBuilder modelBuilder, ISet<Type> types)
	{
		modelBuilder.Entity<CurrencyExchangeRatesJrnl>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("CURRENCY_EXCHANGE_RATES_JRNL");

            entity.HasIndex(e => new { e.Resort, e.BaseCurrCode, e.CurrencyCode, e.ExchangeRateType, e.BeginDate })
                .HasName("EXCH_RATE_JRNL_IND");

            entity.Property(e => e.BaseCurrCode)
                .HasColumnName("BASE_CURR_CODE")
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.BeginDate)
                .HasColumnName("BEGIN_DATE")
                .HasColumnType("DATE")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.BuyCommPerc)
                .HasColumnName("BUY_COMM_PERC")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.BuyForeignExchangeRate)
                .HasColumnName("BUY_FOREIGN_EXCHANGE_RATE")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Comments)
                .HasColumnName("COMMENTS")
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.CurrActionId)
                .HasColumnName("CURR_ACTION_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.CurrencyCode)
                .HasColumnName("CURRENCY_CODE")
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ExchangeRate)
                .HasColumnName("EXCHANGE_RATE")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ExchangeRateType)
                .HasColumnName("EXCHANGE_RATE_TYPE")
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.InsertDate)
                .HasColumnName("INSERT_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.InsertUser)
                .HasColumnName("INSERT_USER")
                .HasColumnType("NUMBER");

            entity.Property(e => e.JrnlBusinessDate)
                .HasColumnName("JRNL_BUSINESS_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.JrnlUser)
                .HasColumnName("JRNL_USER")
                .HasColumnType("NUMBER");

            entity.Property(e => e.LockRateYn)
                .HasColumnName("LOCK_RATE_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.OldCurrActionId)
                .HasColumnName("OLD_CURR_ACTION_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.Resort)
                .HasColumnName("RESORT")
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.SellCommPerc)
                .HasColumnName("SELL_COMM_PERC")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.SellExchangeRate)
                .HasColumnName("SELL_EXCHANGE_RATE")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.SellForeignExchangeRate)
                .HasColumnName("SELL_FOREIGN_EXCHANGE_RATE")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.SystemDate)
                .HasColumnName("SYSTEM_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.UpdateDate)
                .HasColumnName("UPDATE_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.UpdateUser)
                .HasColumnName("UPDATE_USER")
                .HasColumnType("NUMBER");
        });
	}
}
