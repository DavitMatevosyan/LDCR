using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class Course : AuditableEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
}
