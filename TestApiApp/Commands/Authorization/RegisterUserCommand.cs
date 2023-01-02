using LS.Helpers.Hosting.API;

namespace TestApiApp.Commands.Authorization
{
    public class RegisterUserCommand : ICommand<ExecutionResult<string>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
