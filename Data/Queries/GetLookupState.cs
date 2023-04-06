using CallCenter.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CallCenter.Data.Queries;

public class GetLookupState
{
    readonly DefaultDbContextQuery _defaultDbContextQueryReadOnly;
    public GetLookupState(DefaultDbContextQuery defaultDbContextQueryReadOnly)
    {
        _defaultDbContextQueryReadOnly = defaultDbContextQueryReadOnly;
    }

    public async Task<LookupState?> ExecuteAsync(string stateCode)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        var result = await _defaultDbContextQueryReadOnly.LookupStates.FirstOrDefaultAsync(x => x.StateCode == stateCode);
        stopwatch.Stop();
        var timing = stopwatch.ElapsedMilliseconds;
        if (result != null)
        {
            result.Stopwatch = stopwatch;
        }
        return result;
        }
}
