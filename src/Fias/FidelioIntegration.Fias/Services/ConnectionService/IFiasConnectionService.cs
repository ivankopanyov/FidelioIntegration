namespace FidelioIntegration.Fias;

public interface IFiasConnectionService
{
    bool IsRunning { get; set; }

    string? Hostname { get; set; }

    int Port { get; set; }

    internal CancellationToken CancellationToken { get; }

    internal void RefreshCancellationToken();
}

