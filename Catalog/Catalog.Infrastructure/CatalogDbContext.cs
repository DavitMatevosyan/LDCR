using Catalog.Domain.Models;
using Catalog.Infrastructure.EntityConfigurations;
using LDCR.Shared.Constants;
using LDCR.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure;

public class CatalogDbContext : ModuleDbContext
{
    public CatalogDbContext(DbContextOptions opts, IConfiguration configuration) : base(opts, configuration)
    {
        Schema = ModuleConstants.Catalog;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new SessionReferenceConfiguration());
        modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<SessionReference> SessionReferences { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<Note> Notes { get; set; }
}
