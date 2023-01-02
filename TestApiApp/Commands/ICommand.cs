using MediatR;

namespace TestApiApp.Commands
{
    public interface ICommand<out T> : IRequest<T>
    {
    }
}
