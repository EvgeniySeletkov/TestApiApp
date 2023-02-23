using LS.Helpers.Hosting.API;
using LS.Helpers.Hosting.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestApiApp.Commands.Authorization.ResisterUser;
using TestApiApp.Queries.Authorization.Login;

namespace TestApiApp.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Authorization")]
    public class AuthorizationController : BaseController
    {
        public AuthorizationController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost("register")]
        [SwaggerOperation("Create new user")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(ExecutionResult), 200)]
        public async Task<IActionResult> Register(
            [FromBody] RegisterUserCommand createUserCommand, 
            CancellationToken cancellationToken)
            => await ExecuteCommandAsync(createUserCommand, cancellationToken);

        [HttpPost("login")]
        [SwaggerOperation("Log in user and get token")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(ExecutionResult<LoginQueryResult>), 200)]
        public async Task<IActionResult> Login(
            [FromBody] LoginQuery loginQuery, 
            CancellationToken cancellationToken)
            => await ExecuteQueryAsync(loginQuery, cancellationToken);
    }
}
