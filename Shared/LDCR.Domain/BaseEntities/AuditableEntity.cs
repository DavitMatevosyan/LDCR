namespace LDCR.Domain.BaseEntities;

public class AuditableEntity : EntityModel
{
    public DateTime CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }

    public DateTime ModifiedDate { get; set; }
    public Guid ModifiedBy { get; set; }

    public bool IsObsolete { get; set; } = false;
}
