namespace PlantillaMicroAPI.Domain.NombreEntidad
{
    using PlantillaMicroAPI.Domain.Abstractions;

    public sealed class NombreEntidad : Entity
    {
        public NombreEntidad()
        {
        }

        public NombreEntidad(int id)
        {
            this.Id = id;
        }
    }
}
