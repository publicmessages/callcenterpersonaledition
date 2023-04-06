using CallCenter.Data;
using CallCenter.Data.Queries;
using CallCenter.Server.Requests;
using CallCenter.Shared.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class LookupStateController
{
    private readonly ILogger<LookupStateController> _logger;
    private readonly DefaultDbContextQuery _context;
    private readonly IMediator _mediatr;

    public LookupStateController(DefaultDbContextQuery context, IMediator mediatr, ILogger<LookupStateController> logger)
    {
        _context = context;
        _mediatr = mediatr;
        _logger = logger;
    }

    [HttpGet]
    [Route("{StateCode}")]
    public async Task<IResult> GetState(GetStateByStateCodeRequest request)
    {
        _logger.LogInformation("Begin {action} in {controller}", nameof(GetState), nameof(LookupStateController));
        GetLookupState getLookupState = new(request.StateCode, _context);
        LookupState? lookupState = await getLookupState.ExecuteAsync();
        return Results.Ok(new { message = lookupState?.StateName ?? "" });
        //var result = _mediatr.Send(request);
        //return result;
    }
}
