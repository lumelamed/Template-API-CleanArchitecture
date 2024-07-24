namespace PlantillaMicroAPI.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using PlantillaMicroAPI.Domain.Abstractions;
    using PlantillaMicroAPI.Domain.NombreEntidad;

    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<NombreEntidad> Entidad { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron guardar los cambios en la base de datos", ex);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); // escanea el assembly buscando las configuraciones de cada entidad
            base.OnModelCreating(modelBuilder);
        }
    }
}
