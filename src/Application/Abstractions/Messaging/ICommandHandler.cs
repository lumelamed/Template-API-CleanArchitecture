namespace PlantillaMicroAPI.Application.Abstractions.Messaging
{
    using MediatR;
    using PlantillaMicroAPI.Domain.Abstractions;

    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
