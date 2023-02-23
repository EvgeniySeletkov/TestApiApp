using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using TestApiApp.Models.User;

namespace TestApiApp.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<UserModel> UserManager { get; }

        IDbContextTransaction CreateTransaction();
        Task<IDbContextTransaction> CreateTransactionAsync(CancellationToken cancellationToken = default);
        void Commit();
        Task CommitAsync();
    }
}
