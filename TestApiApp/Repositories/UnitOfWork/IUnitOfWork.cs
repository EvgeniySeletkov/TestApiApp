using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using TestApiApp.Models.User;
using TestApiApp.Repositories.Contracts;

namespace TestApiApp.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<UserModel> UserManager { get; }
        IItemRepository ItemRepository { get; }

        IDbContextTransaction CreateTransaction();
        Task<IDbContextTransaction> CreateTransactionAsync(CancellationToken cancellationToken = default);
        void Commit();
        Task CommitAsync();
    }
}
