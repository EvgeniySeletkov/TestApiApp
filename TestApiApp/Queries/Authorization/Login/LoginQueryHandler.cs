using LS.Helpers.Hosting.API;
using TestApiApp.Repositories.UnitOfWork;
using TestApiApp.Services.Token;

namespace TestApiApp.Queries.Authorization.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, ExecutionResult<LoginQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public LoginQueryHandler(
            IUnitOfWork unitOfWork,
            ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<ExecutionResult<LoginQueryResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            ExecutionResult<LoginQueryResult> result;

            try
            {
                var user = await _unitOfWork.UserManager.FindByEmailAsync(request.Email);

                if (user == null || !await _unitOfWork.UserManager.CheckPasswordAsync(user, request.Password))
                {
                    return new ExecutionResult<LoginQueryResult>(new ErrorInfo("Email or password is incorrect"));
                }

                if (!user.EmailConfirmed)
                {
                    return new ExecutionResult<LoginQueryResult>(new ErrorInfo("Email isn't confermed"));
                }

                result = new ExecutionResult<LoginQueryResult>(new LoginQueryResult
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    AccessToken = _tokenService.GenerateAccessToken(user),
                });
            }
            catch (Exception ex)
            {
                result = new ExecutionResult<LoginQueryResult>(new ErrorInfo(ex.Message));
            }

            return result;
        }
    }
}
