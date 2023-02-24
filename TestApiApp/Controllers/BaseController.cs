using LS.Helpers.Hosting.API;
using LS.Helpers.Hosting.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApiApp.Commands;
using TestApiApp.Extensions;
using TestApiApp.Queries;

namespace TestApiApp.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }
        protected string UserId => User.GetUserId();

        protected async Task<IActionResult> ExecuteCommandAsync<T>(ICommand<ExecutionResult<T>> command, CancellationToken cancellationToken)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(command, cancellationToken);

            return this.FromExecutionResult(result);
        }

        protected async Task<IActionResult> ExecuteQueryAsync<T>(IQuery<ExecutionResult<T>> query, CancellationToken cancellationToken)
        {
            if (query is null)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(query, cancellationToken);

            return this.FromExecutionResult(result);
        }
    }
}
