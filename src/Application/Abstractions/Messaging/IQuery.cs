namespace PlantillaMicroAPI.Application.Abstractions.Messaging
{
    using MediatR;
    using PlantillaMicroAPI.Domain.Abstractions;

    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
