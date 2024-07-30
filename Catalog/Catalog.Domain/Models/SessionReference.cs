using LDCR.Domain.BaseEntities;

namespace Catalog.Domain.Models;

public class SessionReference : EntityModel
{
    public IEnumerable<Session>? Sessions { get; set; }
    public IEnumerable<string>? References { get; set; } // url, document, text
}
