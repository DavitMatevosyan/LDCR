using Catalog.Domain.ValueObjects;
using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class Course : AuditableEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public TimeSpan Duration { get; set; }
    public RepetitionRule RepetitionRule { get; set; }
    public DateTime StartDate { get; set; }

    public ICollection<Session>? Sessions { get; set; }
}
