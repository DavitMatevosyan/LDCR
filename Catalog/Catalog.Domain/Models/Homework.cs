using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class Homework : AuditableEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? AcceptanceCriteria { get; set; }

    public Guid? SessionId { get; set; }
    public Session? Session { get; set; }
}
