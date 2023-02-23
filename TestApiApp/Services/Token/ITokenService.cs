using TestApiApp.Models.User;

namespace TestApiApp.Services.Token
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserModel user);
    }
}
