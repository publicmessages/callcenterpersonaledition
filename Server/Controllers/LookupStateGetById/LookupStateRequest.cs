using CallCenter.Shared.Domain;
using MediatR;

namespace CallCenter.Server.Controllers.LookupStateGetById
{
    public class LookupStateRequest : IRequest<LookupState>
    {
        public string StateCode { get; set; }
    }
}
