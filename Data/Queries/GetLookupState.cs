using CallCenter.Shared.Domain;
using Microsoft.EntityFrameworkCore;

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
        return await _defaultDbContextQueryReadOnly.LookupStates.FirstOrDefaultAsync(x => x.StateCode == _stateCode);
    }
}
