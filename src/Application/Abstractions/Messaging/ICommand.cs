namespace PlantillaMicroAPI.Application.Abstractions.Messaging
{
    using MediatR;
    using PlantillaMicroAPI.Domain.Abstractions;

    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }

    public interface IBaseCommand
    {
    }
}
