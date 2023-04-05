namespace CallCenter.Server.App_Start;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
