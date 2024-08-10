using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50); 

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.HasMany(x => x.Sessions)
            .WithOne(x => x.Course);

        builder.HasData(SeedData());
    }

    private static List<Course> SeedData()
        => [
            new()
            {
                Code = "CS101",
                Name = "Intro to CS"
            },
            new()
            {
                Code = "CS201",
                Name = "Programming Details"
            },
            new()
            {
                Code = "CS301",
                Name = "Pragmatic Programmer"
            }
        ];
}
