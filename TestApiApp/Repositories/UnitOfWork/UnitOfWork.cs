using Microsoft.AspNetCore.Identity;
using TestApiApp.Database;
using TestApiApp.Models.User;

namespace TestApiApp.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UserManager<UserModel> UserManager { get; }

        public UnitOfWork(
            ApplicationDbContext dbContext,
            UserManager<UserModel> userManager)
        {
            UserManager = userManager;

            _dbContext = dbContext;
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
