namespace PlantillaMicroAPI.Domain.NombreEntidad
{
    public interface INombreEntidadRepository
    {
        Task<NombreEntidad?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task AddAsync(NombreEntidad user);
    }
}
