using Catalog.Domain.ValueObjects;
using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class Session : AuditableEntity
{
    public required string Topic { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }

    public required Guid? CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public IEnumerable<SessionReference>? SessionReferences { get; set; }
    public IEnumerable<Homework>? Homeworks { get; set; }
    public IEnumerable<Note>? Notes { get; set; }
}
