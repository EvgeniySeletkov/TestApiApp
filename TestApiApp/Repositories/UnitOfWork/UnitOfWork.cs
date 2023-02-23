using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using TestApiApp.Database;
using TestApiApp.Models.User;

namespace TestApiApp.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(
            ApplicationDbContext dbContext,
            UserManager<UserModel> userManager)
        {
            UserManager = userManager;

            _dbContext = dbContext;
        }

        public UserManager<UserModel> UserManager { get; }

        public IDbContextTransaction CreateTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public Task<IDbContextTransaction> CreateTransactionAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
