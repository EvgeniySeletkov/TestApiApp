using LS.Helpers.Hosting.API;
using TestApiApp.Extensions;
using TestApiApp.Models.User;
using TestApiApp.Repositories.UnitOfWork;

namespace TestApiApp.Commands.Authorization.ResisterUser
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, ExecutionResult<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ExecutionResult<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            ExecutionResult<string> result;

            try
            {
                var user = new UserModel
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    EmailConfirmed = true,
                };

                var createResult = await _unitOfWork.UserManager.CreateAsync(user, request.Password);

                result = createResult.Succeeded
                    ? new ExecutionResult<string>(user.Id)
                    : new ExecutionResult<string>(createResult.Errors.Select(e => e.ToErrorInfo()).ToList());
            }
            catch (Exception ex)
            {
                result = new ExecutionResult<string>(new ErrorInfo(ex.Message));
            }

            return result;
        }
    }
}
