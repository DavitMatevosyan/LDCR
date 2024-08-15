using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations;

internal class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Session)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.Id);


        builder.HasData(SeedData());
    }

    private static List<Note> SeedData()
        =>
        [
            new()
            {
                Id = Guid.Parse("2f4cad70-b562-4377-a18d-7b7c705c2e3c"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Description = "Sample Note 1"
            },
            new()
            {
                Id = Guid.Parse("1cedccea-a904-4284-b719-c4891a6e153b"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Description = "Sample Note 2"
            },
            new()
            {
                Id = Guid.Parse("f30e1f87-a9b7-47a7-89dc-aa599574ef4e"),
                SessionId = Guid.Parse("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                Description = "Sample Note 3"
            }
        ];
}
