using LDCR.Infrastructure.DataAccessUtils;

namespace Catalog.Domain.Models;

public class Session : AuditableEntity
{
    public required string Topic { get; set; }
    public string? Description { get; set; }
    public SessionReference? Reference { get; set; }

    public required Course Course { get; set; }

    public IEnumerable<Homework>? Homeworks { get; set; }
    public IEnumerable<Note>? Notes { get; set; }
}
