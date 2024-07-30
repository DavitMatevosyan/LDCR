using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class Note : AuditableEntity
{
    public required string Description { get; set; }


    public required Session Session { get; set; }
}
