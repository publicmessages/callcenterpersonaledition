namespace CallCenter.Server.Requests
{
    public class GetStateByStateCodeRequest : IHttpRequest
    {
        public string StateCode { get; set; } = "";
    }
}
