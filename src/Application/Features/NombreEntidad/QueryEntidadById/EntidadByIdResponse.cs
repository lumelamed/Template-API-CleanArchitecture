namespace PlantillaMicroAPI.Application.Features.NombreEntidad.QueryEntidadById
{
    public sealed class EntidadByIdResponse
    {
        public EntidadByIdResponse(int id)
        {
            this.Id = id;
        }

        public int Id { get; init; }
    }
}
