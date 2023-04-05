namespace CallCenter.Data.Services;

public interface IHandleQueryAsync<TQuery, TResponse>
{
    Task<TResponse> ExecuteAsync(TQuery query);
}

public interface IHandleQueryAsync<TResponse>
{
    Task<TResponse> ExecuteAsync();
}
