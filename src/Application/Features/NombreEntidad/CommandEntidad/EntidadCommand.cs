namespace PlantillaMicroAPI.Application.Features.NombreEntidad.CommandEntidad
{
    using PlantillaMicroAPI.Application.Abstractions.Messaging;

    public record EntidadCommand(object parametros) : ICommand<int>;
}
