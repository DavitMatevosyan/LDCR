using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations;

internal class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Topic)
            .IsUnique()
            .IsClustered(false);

        builder.Property(x => x.Topic)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(300);

        builder.HasOne(x => x.Course)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.SessionReferences)
            .WithOne(x => x.Session)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Homeworks)
            .WithOne(x => x.Session)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Notes)
            .WithOne(x => x.Session)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(SeedData());

    }

    private static List<Session> SeedData()
        =>
        [
            new()
            {
                CourseId = Guid.Parse("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                Topic = "Introduction to Course CS101",
                Id = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Description = "Introduction to Course, will learn a lot of things",
                StartDate = new DateTime(2024, 02, 19, 18, 30, 00)
            },
            new()
            {
                CourseId = Guid.Parse("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                Topic = "Introduction to Course CS101",
                Id = Guid.Parse("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                Description = "Introduction to Course, will learn a lot of things Part 2",
                StartDate = new DateTime(2024, 02, 20, 19, 30, 00)
            },
            new()
            {
                CourseId = Guid.Parse("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                Topic = "Introduction to Course CS101",
                Id = Guid.Parse("2bd3e9ac-32bb-44cb-a427-5a1cab82d0e7"),
                Description = "Introduction to Course, will learn a lot of things Part 3",
                StartDate = new DateTime(2024, 02, 21, 18, 30, 00)
            },
            new()
            {
                CourseId = Guid.Parse("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                Topic = "Programming Details CS201",
                Id = Guid.Parse("9913114a-cb5e-4d00-bf63-ad054a179099"),
                Description = "Programming Details CS201, will learn a lot of things",
                StartDate = new DateTime(2024, 08, 20, 12, 30, 00)
            },
            new()
            {
                CourseId = Guid.Parse("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                Topic = "Programming Details CS201",
                Id = Guid.Parse("fce3bf3f-bdaf-4672-b878-ea05f7e33319"),
                Description = "Programming Details CS201, will learn a lot of things",
                StartDate = new DateTime(2024, 08, 21, 12, 30, 00)
            },
            new()
            {
                CourseId = Guid.Parse("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                Topic = "Programming Details CS201",
                Id = Guid.Parse("9437caa9-9814-49d1-a031-9d77d6bf9005"),
                Description = "Programming Details CS201, will learn a lot of things",
                StartDate = new DateTime(2024, 02, 22, 18, 30, 00)
            },
            new()
            {
                CourseId = Guid.Parse("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                Topic = "Programming Details CS201",
                Id = Guid.Parse("bdd42fa0-197d-4c8b-b02f-492a866ae115"),
                Description = "Programming Details CS201, will learn a lot of things",
                StartDate = new DateTime(2024, 02, 23, 18, 30, 00)
            }
        ];
}
