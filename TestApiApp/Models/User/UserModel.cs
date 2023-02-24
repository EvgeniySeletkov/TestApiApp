using Microsoft.AspNetCore.Identity;
using TestApiApp.Models.Item;

namespace TestApiApp.Models.User
{
    public class UserModel : IdentityUser
    {
        public virtual ICollection<ItemModel> Items { get; set; }
    }
}
