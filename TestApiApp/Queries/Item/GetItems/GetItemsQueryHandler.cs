using LS.Helpers.Hosting.API;
using TestApiApp.Models.Item;
using TestApiApp.Repositories.UnitOfWork;

namespace TestApiApp.Queries.Item.GetItems
{
    public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, ExecutionResult<GetItemsQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetItemsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ExecutionResult<GetItemsQueryResult>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            ExecutionResult<GetItemsQueryResult> result;

			try
			{
                var items = _unitOfWork.ItemRepository.GetItems(i => i.UserId == request.UserId);

                result = new ExecutionResult<GetItemsQueryResult>(new GetItemsQueryResult
                {
                    Items = items.Select(i => new ItemModelDTO
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description,
                    }).ToList(),
                });
			}
			catch (Exception ex)
			{
                result = new ExecutionResult<GetItemsQueryResult>(new ErrorInfo(ex.Message));
			}

            return Task.FromResult(result);
        }
    }
}
