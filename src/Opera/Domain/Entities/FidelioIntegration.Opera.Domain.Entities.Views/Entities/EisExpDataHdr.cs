namespace FidelioIntegration.Opera.Domain.Entities.Views;

public partial class EisExpDataHdr
{
    public decimal ExpDataId { get; set; }
    public decimal ExpFileId { get; set; }
    public string? Resort { get; set; }
    public decimal? TotRecords { get; set; }
    public string? GeneratedFilename { get; set; }
    public string? GeneratedFileextn { get; set; }
    public string? GeneratedFileloc { get; set; }
    public DateTime GeneratedDate { get; set; }
    public decimal InsertUser { get; set; }
    public DateTime InsertDate { get; set; }
    public decimal? UpdateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? InactiveYn { get; set; }
    public decimal? BatchNumber { get; set; }
    public DateTime? DataFromDate { get; set; }
    public DateTime? DataToDate { get; set; }
    public string? ChecksumYn { get; set; }
    public decimal? XmlExpTempId { get; set; }
    public decimal? IterationByDate { get; set; }

	public static void OnModelCreating(ModelBuilder modelBuilder, ISet<Type> types)
	{
		modelBuilder.Entity<EisExpDataHdr>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("EIS_EXP_DATA_HDR");

            entity.Property(e => e.BatchNumber)
                .HasColumnName("BATCH_NUMBER")
                .HasColumnType("NUMBER");

            entity.Property(e => e.ChecksumYn)
                .HasColumnName("CHECKSUM_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.DataFromDate)
                .HasColumnName("DATA_FROM_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.DataToDate)
                .HasColumnName("DATA_TO_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.ExpDataId)
                .HasColumnName("EXP_DATA_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.ExpFileId)
                .HasColumnName("EXP_FILE_ID")
                .HasColumnType("NUMBER");

            entity.Property(e => e.GeneratedDate)
                .HasColumnName("GENERATED_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.GeneratedFileextn)
                .HasColumnName("GENERATED_FILEEXTN")
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.GeneratedFileloc)
                .HasColumnName("GENERATED_FILELOC")
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.GeneratedFilename)
                .HasColumnName("GENERATED_FILENAME")
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.InactiveYn)
                .HasColumnName("INACTIVE_YN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.InsertDate)
                .HasColumnName("INSERT_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.InsertUser)
                .HasColumnName("INSERT_USER")
                .HasColumnType("NUMBER");

            entity.Property(e => e.IterationByDate)
                .HasColumnName("ITERATION_BY_DATE")
                .HasColumnType("NUMBER");

            entity.Property(e => e.Resort)
                .IsRequired()
                .HasColumnName("RESORT")
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.TotRecords)
                .HasColumnName("TOT_RECORDS")
                .HasColumnType("NUMBER");

            entity.Property(e => e.UpdateDate)
                .HasColumnName("UPDATE_DATE")
                .HasColumnType("DATE");

            entity.Property(e => e.UpdateUser)
                .HasColumnName("UPDATE_USER")
                .HasColumnType("NUMBER");

            entity.Property(e => e.XmlExpTempId)
                .HasColumnName("XML_EXP_TEMP_ID")
                .HasColumnType("NUMBER");
        });
	}
}
