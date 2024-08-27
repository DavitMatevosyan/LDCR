using LDCR.Domain.BaseEntities;
using LDCR.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LDCR.Infrastructure.Interceptors;

public class EntityAuditInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var toBeAudited = eventData.Context?.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged && x.State != EntityState.Detached && x.Entity is AuditableEntity);

        // Add logging here time, metadata
        var toBeAuditedEntityList = new List<AuditableEntity>();

        if (toBeAudited is not null)
        {

            foreach (var entry in toBeAudited)
            {
                if (entry.Entity is AuditableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditableEntity.CreatedDate = DateTime.Now;
                            auditableEntity.CreatedBy = Guid.Empty; // this will be changed to Changer's account id
                            auditableEntity.IsObsolete = false;
                            break;
                        case EntityState.Modified:
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy = Guid.Empty; // this will be changed to changer's account id
                            auditableEntity.IsObsolete = false;
                            break;
                        case EntityState.Deleted:
                            auditableEntity.IsObsolete = true;
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy = Guid.Empty; // this will be changed to changer's account id

                            entry.State = EntityState.Modified;
                            break;
                        default:
                            continue;
                    }

                    toBeAuditedEntityList.Add(auditableEntity);
                }
            }
        }

        if (eventData.Context is ModuleDbContext dbContext)
            dbContext.EntityAudits.AddRange(toBeAuditedEntityList);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        // log time here

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    public override async Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        // log error here

        await base.SaveChangesFailedAsync(eventData, cancellationToken);
    }
}
