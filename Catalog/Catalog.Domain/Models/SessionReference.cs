using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class SessionReference : EntityModel
{
    public string? Reference { get; set; } // url, document, text

    public Guid SessionId { get; set; }
    public Session Session { get; set; } = null!;
}
