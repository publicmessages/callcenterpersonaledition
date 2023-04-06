using MediatR;

namespace CallCenter.Server.Requests
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
