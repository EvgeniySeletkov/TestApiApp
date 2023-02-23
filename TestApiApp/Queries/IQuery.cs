using MediatR;

namespace TestApiApp.Queries
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
