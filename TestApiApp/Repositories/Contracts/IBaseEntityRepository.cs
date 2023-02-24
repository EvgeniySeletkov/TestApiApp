using System.Linq.Expressions;

namespace TestApiApp.Repositories.Contracts
{
    public interface IBaseEntityRepository<T> where T : class, new()
    {
        Task AddAsync(T entity);

        void Add(T entity);

        IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate);
    }
}
