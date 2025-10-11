using Planner.Data.Models;

namespace Planner.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    ICrudRepository<T> GetRepository<T>() where T : class, IModel;
}