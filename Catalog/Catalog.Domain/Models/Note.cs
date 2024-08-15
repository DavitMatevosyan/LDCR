using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class Note : AuditableEntity
{
    public required string Description { get; set; }

    public Guid? SessionId { get; set; }
    public Session? Session { get; set; }
}
