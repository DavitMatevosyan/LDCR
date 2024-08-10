using Catalog.Domain.Models;
using Catalog.Infrastructure.EntityConfigurations;
using LDCR.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure;

public class CatalogDbContext : ModuleDbContext
{
    public CatalogDbContext(DbContextOptions opts, IConfiguration configurtion) : base(opts, configurtion)
    {
        Schema = "Catalog";
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    public DbSet<Course> Courses { get; set; }
}
