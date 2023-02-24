using LS.Helpers.Hosting.API;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestApiApp.Commands.Authorization.ResisterUser;
using TestApiApp.Commands.Item.Create;
using TestApiApp.Models.Item;
using TestApiApp.Queries.Item.GetItems;

namespace TestApiApp.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Item")]
    public class ItemController : BaseController
    {
        public ItemController(
            IMediator mediator) 
            : base(mediator)
        {
        }

        [Authorize]
        [HttpPost("create-item")]
        [SwaggerOperation("Create new item")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(ExecutionResult), 200)]
        public async Task<IActionResult> CreateItem(
            [FromBody] CreateItemRequest createItemRequest,
            CancellationToken cancellationToken)
            => await ExecuteCommandAsync(new CreateItemCommand
            {
                Name = createItemRequest.Name,
                Description = createItemRequest.Description,
                UserId = UserId,
            }, cancellationToken);

        [Authorize]
        [HttpGet("get-items")]
        [SwaggerOperation("Get items")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(ExecutionResult), 200)]
        public async Task<IActionResult> GetItems(CancellationToken cancellationToken)
            => await ExecuteQueryAsync(new GetItemsQuery
            {
                UserId = UserId,
            }, cancellationToken);
    }
}
