using Catalog.Domain.Models;
using Catalog.Infrastructure.EntityConfigurations;
using LDCR.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure;

public class CatalogDbContext(IConfiguration config, DbContextOptions opts) : ModuleDbContext(config, opts)
{
    protected override string Schema => "Catalog";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CourseConfiguration());
    }

    public DbSet<Course> Courses { get; set; }

}
