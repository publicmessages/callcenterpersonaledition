using CallCenter.Data;
using CallCenter.Server.Requests;
using MediatR;
using System.Diagnostics;

namespace CallCenter.Server.Handlers
{
    public class GetStateByStateCodeHandler : IRequestHandler<GetStateByStateCodeRequest, IResult>
    {
        private readonly DefaultDbContextQuery _context;
        public GetStateByStateCodeHandler(DefaultDbContextQuery context)
        {
            _context = context;
        }
        public async Task<IResult> Handle(GetStateByStateCodeRequest request, CancellationToken cancellationToken)
        {
            Data.Queries.GetLookupState getLookupState = new(_context);
            Shared.Domain.LookupState? lookupState = await getLookupState.ExecuteAsync(request.StateCode);
            return Results.Ok(new { message = "Hola mundo!" });
        }
    }
}
