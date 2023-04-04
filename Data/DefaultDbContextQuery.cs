using Microsoft.EntityFrameworkCore;

namespace CallCenter.Data;

public sealed class DefaultDbContextQuery : DefaultDbContext<DefaultDbContextQuery>
{
    public DefaultDbContextQuery(DbContextOptions<DefaultDbContextQuery> options)
       : base(options)
    {
    }
}
