using CallCenter.Data.Services;
using CallCenter.Shared.Domain;

namespace CallCenter.Server.App_Start;

public static class HandlersRegistration
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection services)
    {
        //Query Handlers
        //services.AddTransient<IHandleQueryAsync<Guid, Response<LookupState>>, GetLookupStateQueryHandler>();
        return services;
    }
}
