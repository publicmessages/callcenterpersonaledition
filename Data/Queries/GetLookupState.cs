using CallCenter.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CallCenter.Data.Queries;

public class GetLookupState
{
    readonly DefaultDbContextQuery _defaultDbContextQueryReadOnly;
    readonly string _stateCode;
    public GetLookupState(string stateCode, DefaultDbContextQuery defaultDbContextQueryReadOnly)
    {
        _stateCode = stateCode;
        _defaultDbContextQueryReadOnly = defaultDbContextQueryReadOnly;
    }

    public async Task<LookupState?> ExecuteAsync()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        var result = await _defaultDbContextQueryReadOnly.LookupStates.FirstOrDefaultAsync(x => x.StateCode == _stateCode);
        stopwatch.Stop();
        var timing = stopwatch.ElapsedMilliseconds;
        if (result != null)
        {
            result.Stopwatch = stopwatch;
        }
        return result;
    }
}
