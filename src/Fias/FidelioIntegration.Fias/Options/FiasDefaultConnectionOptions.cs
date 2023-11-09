namespace FidelioIntegration.Fias;

public class FiasDefaultConnectionOptions
{
	public const string SectionName = "FiasDefaultConnection";

    public string? DefaultHostname { get; set; }

	public int DefaultPort { get; set; }

	public bool DefaultRunning { get; set; }
}

