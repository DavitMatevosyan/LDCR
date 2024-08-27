using LDCR.Domain.BaseEntities;
using System.Linq.Expressions;

namespace LDCR.Domain.Contracts;

public interface IBaseRepository<T> where T : EntityModel
{
    /// <summary>
    /// Gets the item with given <paramref name="id"/>, if not found throws an exception
    /// </summary>
    /// <param name="id">id of the item</param>
    /// <param name="asNoTracking">if the item needs to be tracked</param>
    /// <param name="token">Cancellation Token</param>
    /// <returns>Item with Id = <paramref name="id"/></returns>
    Task<T> GetAsync(Guid id, bool asNoTracking = false, CancellationToken token = default);

    /// <summary>
    /// Gets the items satisfying the given <paramref name="predicate"/>, if not found throws an exception
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <param name="asNoTracking">if the item needs to be tracked</param>
    /// <param name="token">Cancellation Token</param>
    /// <returns>Items satisfying the given <paramref name="predicate"/></returns>
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int page, int pageSize, bool asNoTracking = false,  CancellationToken token = default);

    /// <summary>
    /// Add <paramref name="entity"/> to Database
    /// </summary>
    /// <param name="entity">Item to add</param>
    /// <param name="token">Cancellation Token</param>
    /// <returns>Added Item</returns>
    Task<T> AddAsync(T entity, CancellationToken token);

    /// <summary>
    /// Deletes the item from Database (makes isObsolete = 1)
    /// </summary>
    /// <param name="id">id of the item</param>
    /// <param name="token">Cancellation Token</param>
    Task DeleteAsync(Guid id, CancellationToken token);

    /// <summary>
    /// Updates the item in Database
    /// </summary>
    /// <param name="id">id of the item</param>
    /// <param name="newItem">Updated item</param>
    /// <param name="token">Cancellation Token</param>
    Task UpdateAsync(Guid id, T newItem, CancellationToken token);

    /// <summary>
    /// Saves all changed entries
    /// </summary>
    /// <returns>returns the number of rows modified</returns>
    Task<int> SaveChangesAsync();
}
