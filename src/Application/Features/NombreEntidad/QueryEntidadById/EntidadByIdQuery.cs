namespace PlantillaMicroAPI.Application.Features.NombreEntidad.QueryEntidadById
{
    using PlantillaMicroAPI.Application.Abstractions.Messaging;

    public sealed record EntidadByIdQuery(int id) : IQuery<EntidadByIdResponse>
    {
    }
}
