using LS.Helpers.Hosting.API;

namespace TestApiApp.Commands.Authorization.ResisterUser
{
    public class RegisterUserCommand : ICommand<ExecutionResult<string>>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
