using CallCenter.Data;
using CallCenter.Data.Queries;
using CallCenter.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class LookupStatesController : ControllerBase
{
    private readonly ILogger<LookupStatesController> _logger;
    private readonly DefaultDbContextQuery _context;

    public LookupStatesController(DefaultDbContextQuery context, ILogger<LookupStatesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<LookupState>> GetStates()
    {
        _logger.LogInformation("Begin {action} in {controller}", nameof(GetStates), nameof(LookupStatesController));
        GetLookupStates getLookupStates = new(_context);
        List<LookupState> lookupStates = await getLookupStates.ExecuteAsync();
        return lookupStates;
    }
}
