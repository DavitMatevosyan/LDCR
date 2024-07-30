using LDCR.Infrastructure.DataAccessUtils;

namespace Catalog.Domain.Models;

public class Homework : AuditableEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? AcceptanceCriteria { get; set; }

    public required Session Session { get; set; }
}
