using LS.Helpers.Hosting.API;
using TestApiApp.Commands.Authorization;
using TestApiApp.Models.User;
using TestApiApp.Repositories.UnitOfWork;

namespace TestApiApp.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ExecutionResult<string>> RegisterUserAsync(RegisterUserCommand request)
        {
            ExecutionResult<string> result;

            try
            {
                var user = new UserModel
                {
                    Email = request.Email,
                };

                await _unitOfWork.UserManager.CreateAsync(user, request.Password);

                result = new ExecutionResult<string>(user.Id);
            }
            catch (Exception ex)
            {
                result = new ExecutionResult<string>(new ErrorInfo(ex.Message));
            }

            return result;
        }
    }

    public interface IAuthorizationService
    {
        Task<ExecutionResult<string>> RegisterUserAsync(RegisterUserCommand request);
    }
}
