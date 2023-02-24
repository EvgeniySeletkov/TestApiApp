using TestApiApp.Database;
using TestApiApp.Models.Item;
using TestApiApp.Repositories.Contracts;

namespace TestApiApp.Repositories
{
    public class ItemRepository : BaseEntityRepository<ItemModel>, IItemRepository
    {
        public ItemRepository(
            ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
    }
}
