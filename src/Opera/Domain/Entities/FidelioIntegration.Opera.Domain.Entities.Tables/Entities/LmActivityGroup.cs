namespace FidelioIntegration.Opera.Domain.Entities.Tables;

public partial class LmActivityGroup
{
    public string? ActGroupCode { get; set; }
    public string? Resort { get; set; }
    public string? GroupDesc { get; set; }
    public decimal? OrderBy { get; set; }
    public DateTime? InactiveDate { get; set; }
    public DateTime InsertDate { get; set; }
    public decimal InsertUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public decimal UpdateUser { get; set; }

	public static void OnModelCreating(ModelBuilder modelBuilder, ISet<Type> types)
	{
		modelBuilder.Entity<LmActivityGroup>(entity =>
        {
            entity.HasKey(e => new { e.ActGroupCode, e.Resort })
                .HasName("LM_ACTIVITY_GROUP_PK");

            entity.ToTable("LM_ACTIVITY_GROUP");

            entity.Property(e => e.ActGroupCode)
                .HasColumnName("ACT_GROUP_CODE")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Resort)
                .HasColumnName("RESORT")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.GroupDesc)
                .IsRequired()
                .HasColumnName("GROUP_DESC")
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.InactiveDate)
                .HasColumnName("INACTIVE_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.InsertDate)
                .HasColumnName("INSERT_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.InsertUser)
                .HasColumnName("INSERT_USER")
                .HasColumnType("NUMBER");

            entity.Property(e => e.OrderBy)
                .HasColumnName("ORDER_BY")
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
