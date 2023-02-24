using LS.Helpers.Hosting.API;

namespace TestApiApp.Commands.Item.Create
{
    public class CreateItemCommand : ICommand<ExecutionResult<string>>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }
    }
}
