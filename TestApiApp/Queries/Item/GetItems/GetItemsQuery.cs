using LS.Helpers.Hosting.API;

namespace TestApiApp.Queries.Item.GetItems
{
    public class GetItemsQuery : IQuery<ExecutionResult<GetItemsQueryResult>>
    {
        public string UserId { get; set; }
    }
}
