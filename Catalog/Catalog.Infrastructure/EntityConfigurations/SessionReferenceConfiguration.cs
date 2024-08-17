using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations;

internal class SessionReferenceConfiguration : IEntityTypeConfiguration<SessionReference>
{
    public void Configure(EntityTypeBuilder<SessionReference> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Session)
            .WithMany(x => x.SessionReferences);

        builder.HasData(SeedData());
    }

    private static List<SessionReference> SeedData()
        =>
        [
            new()
            {
                Id = Guid.Parse("fbc3a10f-578a-4f3d-975b-b9c9410a7aaa"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Reference = "Sample reference 1"
            },
            new()
            {
                Id = Guid.Parse("86f842dc-27a9-4327-b91b-87ec7537b212"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Reference = "Sample reference 2"
            },
            new()
            {
                Id = Guid.Parse("8ac5adf8-c074-4818-8664-7e8367cbf552"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Reference = "Sample reference 3"
            },
            new()
            {
                Id = Guid.Parse("d1ef9757-b333-402a-8d3c-98d8b878ba30"),
                SessionId = Guid.Parse("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                Reference = "Sample reference 1"
            }
        ];
}
