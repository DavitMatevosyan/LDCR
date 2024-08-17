using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations;

internal class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
{
    public void Configure(EntityTypeBuilder<Homework> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Session)
            .WithMany(x => x.Homeworks);

        builder.HasData(SeedData());
    }

    private static List<Homework> SeedData()
        =>
        [
            new()
            {
                Id = Guid.Parse("98030dcf-df14-4cf3-a0c4-47062adce75a"),
                Title = "Homework 1",
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Description = "Sample Homework 1"
            },
            new()
            {
                Id = Guid.Parse("0774b0b6-6dac-4bf4-b4ce-023491f81a71"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Title = "Homework 2",
                Description = "Sample Homework 2"

            },
            new()
            {
                Id = Guid.Parse("17aef592-7b32-4330-b21d-31f53a530c7b"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Title = "Homework 3",
                Description = "Sample Homework 3"
            },
            new()
            {
                Id = Guid.Parse("f07004aa-4feb-48a4-ada5-2c49bc37d5e0"),
                SessionId = Guid.Parse("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                Title = "Homework 1",
                Description = "Sample Homework 1"
            },
            new()
            {
                Id = Guid.Parse("57b2c785-55f5-4b08-b2c0-6e6b71724000"),
                SessionId = Guid.Parse("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                Title = "Homework 2",
                Description = "Sample Homework 2"
            },
            new()
            {
                Id = Guid.Parse("e84fd466-c932-486f-a482-b0d6c2885dab"),
                SessionId = Guid.Parse("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                Title = "Homework 3",
                Description = "Sample Homework 3"
            }
        ];
}
