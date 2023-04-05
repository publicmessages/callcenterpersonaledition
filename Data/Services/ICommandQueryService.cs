namespace CallCenter.Data.Services;

public interface ICommandQueryService
{
    Task<TResponse> ExecuteQueryAsync<TResponse>();
}
