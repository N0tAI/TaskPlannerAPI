using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Thayen.WebPlanner.Data.Models;

namespace Thayen.WebPlanner.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly PlannerContext _context;
    private readonly ILoggerFactory _loggerFactory;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(PlannerContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _loggerFactory = loggerFactory;
    }

    public ICrudRepository<T> GetRepository<T>() where T : class, IModel
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            var repositoryInstance = new CrudRepository<T>(_context, _loggerFactory);
            _repositories[type] = repositoryInstance;
        }
        return (ICrudRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}