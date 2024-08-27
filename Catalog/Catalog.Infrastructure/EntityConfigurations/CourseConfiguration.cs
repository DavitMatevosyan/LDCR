using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.Code);

        builder.HasMany(x => x.Sessions)
            .WithOne(x => x.Course)
            .OnDelete(DeleteBehavior.Cascade);

        var data = SeedData();

        builder.HasData(data);
    }

    private static List<Course> SeedData()
        => [
            new()
            {
                Id = Guid.Parse("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                Code = "CS101",
                Name = "Intro to CS",
                Duration = TimeSpan.FromMinutes(90),
                RepetitionRule = Domain.ValueObjects.RepetitionRule.WeekDays,
                StartDate = new DateTime(2024, 02, 12, 18, 30, 00)
            },
            new()
            {
                Id = Guid.Parse("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                Code = "CS201",
                Name = "Programming Details",
                Duration = TimeSpan.FromMinutes(60),
                RepetitionRule = Domain.ValueObjects.RepetitionRule.Weekends,
                StartDate = new DateTime(2024, 08, 20, 12, 30, 00)
            },
            new()
            {
                Id = Guid.Parse("223030a6-c3fe-4802-80c7-d22cdb02d569"),
                Code = "CS301",
                Name = "Pragmatic Programmer",
                Duration = TimeSpan.FromMinutes(120),
                RepetitionRule = Domain.ValueObjects.RepetitionRule.WeekDays,
                StartDate = new DateTime(2024, 02, 20, 20, 30, 00)
            }
        ];
}
