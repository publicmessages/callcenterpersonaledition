using CallCenter.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.Data;

public class DefaultDbContext<T> : DbContext
        where T : DbContext
{
    //private readonly string _connectionString;

    public DefaultDbContext(DbContextOptions<T> options)
           : base(options)
    {
    }

    public virtual DbSet<LookupState> LookupStates { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
    {   
        //if (!optionsBuilder.IsConfigured)
        //{
        //    optionsBuilder.UseSqlServer();
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LookupState>(entity =>
        {
            entity.HasKey(e => e.StateCode);

            entity.ToTable("LUP_State");

            entity.Property(e => e.StateCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
    }

}
