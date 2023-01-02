using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TestApiApp.Models.User;

namespace TestApiApp.Database
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
    }
}
