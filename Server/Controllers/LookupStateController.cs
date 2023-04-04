using CallCenter.Data;
using CallCenter.Data.Queries;
using CallCenter.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class LookupStateController : ControllerBase
{
    private readonly ILogger<LookupStateController> _logger;
    private readonly DefaultDbContextQuery _context;

    public LookupStateController(DefaultDbContextQuery context, ILogger<LookupStateController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<LookupState>> GetStates()
    {
        _logger.LogInformation("Begin {action} in {controller}", nameof(GetStates), nameof(LookupStateController));
        GetLookupStates getLookupStates = new(_context);
        List<LookupState> lookupStates = await getLookupStates.ExecuteAsync();
        return lookupStates;
    }
}
