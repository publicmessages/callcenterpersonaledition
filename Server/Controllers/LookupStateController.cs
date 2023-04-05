using CallCenter.Data;
using CallCenter.Data.Queries;
using CallCenter.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class LookupStateController
{
    private readonly ILogger<LookupStateController> _logger;
    private readonly DefaultDbContextQuery _context;

    public LookupStateController(DefaultDbContextQuery context, ILogger<LookupStateController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<LookupState> GetState(string stateCode)
    {
        _logger.LogInformation("Begin {action} in {controller}", nameof(GetState), nameof(LookupStateController));
        GetLookupState getLookupState = new(stateCode, _context);
        LookupState? lookupState = await getLookupState.ExecuteAsync();
        return lookupState ?? new();
    }
}
