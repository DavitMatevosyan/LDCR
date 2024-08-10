using Catalog.Domain.ValueObjects;
using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class Session : AuditableEntity
{
    public required string Topic { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan Duration { get; set; }
    public RepetitionRule RepetitionRule { get; set; }

    public Guid SessionReferenceId { get; set; }
    public SessionReference? Reference { get; set; }

    public required Guid CourseId { get; set; }
    public required Course Course { get; set; }

    public IEnumerable<Homework>? Homeworks { get; set; }
    public IEnumerable<Note>? Notes { get; set; }
}
