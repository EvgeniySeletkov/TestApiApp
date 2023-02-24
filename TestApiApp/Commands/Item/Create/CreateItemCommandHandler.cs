using LS.Helpers.Hosting.API;
using TestApiApp.Models.Item;
using TestApiApp.Repositories.UnitOfWork;

namespace TestApiApp.Commands.Item.Create
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand, ExecutionResult<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ExecutionResult<string>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            ExecutionResult<string> result;

            try
            {
                var item = new ItemModel
                {
                    Name = request.Name,
                    Description = request.Description,
                    UserId = request.UserId,
                };

                await _unitOfWork.ItemRepository.AddAsync(item);

                await _unitOfWork.CommitAsync();

                result = new ExecutionResult<string>(item.Id.ToString());
            }
            catch (Exception ex)
            {
                result = new ExecutionResult<string>(new ErrorInfo(ex.Message));
            }

            return result;
        }
    }
}
