using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Data;

public sealed class DefaultDbContextQuery : DefaultDbContext<DefaultDbContextQuery>
{
    public DefaultDbContextQuery(DbContextOptions<DefaultDbContextQuery> options)
       : base(options)
    {
    }
}
