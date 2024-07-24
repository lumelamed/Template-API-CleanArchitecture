namespace PlantillaMicroAPI.Infrastructure.Repositories
{
    using PlantillaMicroAPI.Domain.NombreEntidad;

    public sealed class NombreEntidadRepository : BaseRepository<NombreEntidad>, INombreEntidadRepository
    {
        public NombreEntidadRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
