namespace PlantillaMicroAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PlantillaMicroAPI.Domain.Abstractions;

    public abstract class BaseRepository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext dbContext;

        protected BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await this.dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task AddAsync(T entity)
        {
            await this.dbContext.AddAsync(entity);
        }
    }
}
