using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Thayen.WebPlanner.Data.Models;

namespace Thayen.WebPlanner.Data;

public class CrudRepository<T> : Repository, ICrudRepository<T>
	where T : class, IModel
{
	protected readonly DbSet<T> _dbSet;
	public CrudRepository(PlannerContext ctx, ILoggerFactory logger) : base(ctx, logger)
	{
		_dbSet = ctx.Set<T>();
	}

	public async Task<bool> CreateAsync(T entity)
	{
		var tracker = await _dbSet.AddAsync(entity);
		if (tracker.State == EntityState.Added)
			return true;
		return false;
	}
	public IAsyncEnumerable<T> RetrieveAsync(IEnumerable<Expression<Func<T, bool>>> filters)
	{
		var query = _dbSet.AsNoTracking();
		foreach (var filter in filters)
			query = query.Where(filter);
		return query.AsAsyncEnumerable();
	}

	public Task<T?> GetByIdAsync(IdType id)
		=> _dbSet.FindAsync(id).AsTask();

	public Task<bool> UpdateAsync(T entity)
	{
		var entry = _dbSet.Update(entity);
		return Task.FromResult(entry != null && entry.State == EntityState.Modified);
	}

	public Task<bool> DeleteAsync(T entity)
	{
		var entry = _dbSet.Remove(entity);
		return Task.FromResult(entry != null && entry.State == EntityState.Deleted);
	}

	public async Task<bool> DeleteByIdAsync(IEnumerable<IdType> ids)
	{
		var entity = await _dbSet.FindAsync(ids);
		if (entity != null)
		{
			_dbSet.Remove(entity);
			return true;
		}
		return false;
	}
}