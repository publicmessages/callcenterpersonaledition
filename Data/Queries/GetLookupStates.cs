using CallCenter.Shared.Domain;
using Microsoft.EntityFrameworkCore;

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
        return await _defaultDbContextQueryReadOnly.LookupStates.ToListAsync();
    }
}
