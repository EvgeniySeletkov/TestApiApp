using LS.Helpers.Hosting.API;
using LS.Helpers.Hosting.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestApiApp.Commands.Authorization;

namespace TestApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Authorization")]
    public class AuthorizationController : Controller
    {
        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [SwaggerOperation("Create new user")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(ExecutionResult), 200)]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand createUserCommand)
        {
            

            var createUserCommandResult = await _mediator.Send(createUserCommand);

            return createUserCommandResult.Success
                ? Ok(createUserCommandResult)
                : this.FromExecutionResult(createUserCommandResult);
        }
    }
}
