using LDCR.Domain.BaseEntities;
using LDCR.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace LDCR.Shared.Infrastructure;

public class ModuleDbContext(DbContextOptions opts, IConfiguration configuration) : DbContext(opts)
{
    protected readonly IConfiguration configuration = configuration;

    protected string? Schema { get; init; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (string.IsNullOrWhiteSpace(Schema))
            return;

        builder.UseSqlServer(configuration.GetConnectionString(Schema), options =>
        {
            options.MigrationsHistoryTable("EFMigrationHistory", Schema);
            options.MigrationsAssembly($"{Schema}.Infrastructure");
        })
            .AddInterceptors(new EntityAuditInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrEmpty(Schema))
            modelBuilder.HasDefaultSchema(Schema);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<AuditableEntity> EntityAudits { get; set; }
}
