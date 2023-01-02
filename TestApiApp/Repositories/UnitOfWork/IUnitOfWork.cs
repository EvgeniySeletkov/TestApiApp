using Microsoft.AspNetCore.Identity;
using TestApiApp.Models.User;

namespace TestApiApp.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<UserModel> UserManager { get; }

        void Commit();
        Task CommitAsync();
    }
}
