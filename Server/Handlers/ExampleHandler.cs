using CallCenter.Server.Requests;
using MediatR;

namespace CallCenter.Server.Handlers
{
    public class ExampleHandler : IRequestHandler<ExampleRequest, IResult>
    {
        public async Task<IResult> Handle(ExampleRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return Results.Ok(new { message = "Hola mundo!" });
        }
    }
}
