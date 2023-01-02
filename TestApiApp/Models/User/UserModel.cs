using Microsoft.AspNetCore.Identity;

namespace TestApiApp.Models.User
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
