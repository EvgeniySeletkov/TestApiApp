using LS.Helpers.Hosting.API;

namespace TestApiApp.Queries.Authorization.Login
{
    public class LoginQuery : IQuery<ExecutionResult<LoginQueryResult>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
