using LDCR.Domain.BaseEntities;
using LDCR.Domain.Contracts;
using LDCR.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LDCR.Infrastructure.Implementations;

public class BaseRepository<T>(ModuleDbContext context) : IBaseRepository<T> where T : EntityModel
{
    private readonly ModuleDbContext context = context;

    public async Task<T> GetAsync(Guid id, bool asNoTracking = false, CancellationToken token = default)
        => await context
            .Set<T>()
            .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll)
            .FirstOrDefaultAsync(x => x.Id == id, token) 
                ?? throw new KeyNotFoundException($"The entity with given id: {id} is not found");

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, CancellationToken token = default)
        => await context
            .Set<T>()
            .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll)
            .Where(predicate)
            .ToListAsync(token)
                ?? throw new KeyNotFoundException($"The entity with given predicate is not found");

    public async Task<T> AddAsync(T entity, CancellationToken token)
        => (await context.Set<T>().AddAsync(entity, token)).Entity;

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var entity = await GetAsync(id, true, token);

        // understand how to make it obsolete 1
        context.Set<T>().Remove(entity);
    }

    public async Task UpdateAsync(Guid id, T newItem, CancellationToken token)
    {
        var entity = await GetAsync(id, true, token);

        newItem.Id = entity.Id;

        context.Set<T>().Update(newItem);
    }
}
