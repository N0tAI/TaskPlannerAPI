using Thayen.WebPlanner.Data.Models;

namespace Thayen.WebPlanner.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    ICrudRepository<T> GetRepository<T>() where T : class, IModel;
}