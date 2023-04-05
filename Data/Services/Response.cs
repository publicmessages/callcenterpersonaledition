namespace CallCenter.Data.Services;

public class Response<T> where T : class
{
    public T? Result { get; set; }
}
