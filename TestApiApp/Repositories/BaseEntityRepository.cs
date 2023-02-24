using System.Linq.Expressions;
using TestApiApp.Database;
using TestApiApp.Models;
using TestApiApp.Repositories.Contracts;

namespace TestApiApp.Repositories
{
    public class BaseEntityRepository<T> : IBaseEntityRepository<T>
        where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BaseEntityRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Add(T entity)
        {
            _applicationDbContext.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _applicationDbContext.Set<T>().AddAsync(entity);
        }

        public IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            return _applicationDbContext.Set<T>().Where(predicate);
        }
    }
}
