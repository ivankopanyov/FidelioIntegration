namespace FidelioIntegration.Fias;

public static class FiasDependencyInjection
{
    public static IServiceCollection AddFias(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<FiasDefaultConnectionOptions>()
            .Bind(configuration.GetSection(FiasDefaultConnectionOptions.SectionName));

        serviceCollection.AddSingleton<IFiasService, FiasService>();
        serviceCollection.AddHostedService<FiasSocketClient>();

        return serviceCollection;
    }
}
