using CallCenter.Data.Queries;
using CallCenter.Server.Requests;
using CallCenter.Shared.Domain;
using MediatR;

namespace CallCenter.Server.Handlers
{
    public class ExampleHandler : IRequestHandler<ExampleRequest, IResult>
    {
        private GetLookupState _query;
        public ExampleHandler(GetLookupState query)
        {
            _query = query;
        }
        public async Task<IResult> Handle(ExampleRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            LookupState? state = await _query.ExecuteAsync(request.StateCode);
            return Results.Ok(new
            { 
                message = "Hola mundo!",
                stateName = state?.StateName
            });
        }
    }
}
