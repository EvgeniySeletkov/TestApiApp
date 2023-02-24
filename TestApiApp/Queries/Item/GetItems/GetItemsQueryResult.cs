using TestApiApp.Models.Item;

namespace TestApiApp.Queries.Item.GetItems
{
    public class GetItemsQueryResult
    {
        public ICollection<ItemModelDTO> Items { get; set; }
    }
}
