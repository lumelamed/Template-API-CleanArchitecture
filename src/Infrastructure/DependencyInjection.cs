namespace PlantillaMicroAPI.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PlantillaMicroAPI.Application.Abstractions.CoreServices;
    using PlantillaMicroAPI.Domain.Abstractions;
    using PlantillaMicroAPI.Domain.NombreEntidad;
    using PlantillaMicroAPI.Infrastructure.CoreServices;
    using PlantillaMicroAPI.Infrastructure.Repositories;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<ICoreService, CoreService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnectionString"));
            });

            services.AddScoped<INombreEntidadRepository, NombreEntidadRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
