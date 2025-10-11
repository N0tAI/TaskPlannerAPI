using System.Linq.Expressions;
using Thayen.WebPlanner.Data.Models;

namespace Thayen.WebPlanner.Data;

public interface ICrudRepository<T>
	where T : class, IModel
{
	Task<bool> CreateAsync(T entity);
	Task<T?> GetByIdAsync(IdType id);
	IAsyncEnumerable<T> RetrieveAsync(IEnumerable<Expression<Func<T, bool>>> filters);
	Task<bool> UpdateAsync(T entity);
	Task<bool> DeleteAsync(T entity);
	Task<bool> DeleteByIdAsync(IEnumerable<IdType> ids);
}