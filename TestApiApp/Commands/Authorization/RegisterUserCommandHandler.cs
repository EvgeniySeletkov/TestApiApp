using LS.Helpers.Hosting.API;
using TestApiApp.Services.Authorization;

namespace TestApiApp.Commands.Authorization
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, ExecutionResult<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public RegisterUserCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public Task<ExecutionResult<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return _authorizationService.RegisterUserAsync(request);
        }
    }
}
