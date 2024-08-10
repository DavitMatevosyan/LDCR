using LDCR.Domain.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LDCR.Shared.Infrastructure;

public abstract class ModuleDbContext(IConfiguration configuration, DbContextOptions opts) : DbContext(opts)
{
    private readonly IConfiguration configuration = configuration;

    protected abstract string Schema { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (string.IsNullOrWhiteSpace(Schema))
            return;

        builder.UseSqlServer(configuration.GetConnectionString(Schema), options =>
        {
            options.MigrationsHistoryTable("EFMigrationHistory", Schema);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrEmpty(Schema))
            modelBuilder.HasDefaultSchema(Schema);

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var toBeAudited = this.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged && x.Entity is AuditableEntity);
        foreach (var entry in toBeAudited)
        {
            if (entry.State == EntityState.Added)
            {

            }
            else if (entry.State == EntityState.Modified)
            {

            }
            else if (entry.State == EntityState.Deleted)
            {

            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
