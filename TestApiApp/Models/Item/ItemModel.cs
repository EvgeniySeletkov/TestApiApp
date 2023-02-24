using System.ComponentModel.DataAnnotations.Schema;
using TestApiApp.Models.User;

namespace TestApiApp.Models.Item
{
    public class ItemModel : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserModel User { get; set; }
    }
}
