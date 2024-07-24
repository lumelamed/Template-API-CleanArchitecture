namespace PlantillaMicroAPI.Application.Abstractions.Messaging
{
    using MediatR;
    using PlantillaMicroAPI.Domain.Abstractions;

    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
