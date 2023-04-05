using CallCenter.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CallCenter.Data.Queries;

public class GetLookupStates
{
    readonly DefaultDbContextQuery _defaultDbContextQueryReadOnly;
    public GetLookupStates(DefaultDbContextQuery defaultDbContextQueryReadOnly)
    {
        _defaultDbContextQueryReadOnly = defaultDbContextQueryReadOnly;
    }

    public async Task<List<LookupState>> ExecuteAsync()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        var result = await _defaultDbContextQueryReadOnly.LookupStates.ToListAsync();
        stopwatch.Stop();
        if (result != null && result.Any())
        {
            result.First().Stopwatch = stopwatch;
        }
        return result;
    }
}
