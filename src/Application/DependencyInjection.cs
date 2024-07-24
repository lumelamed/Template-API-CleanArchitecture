namespace PlantillaMicroAPI.Application
{
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using PlantillaMicroAPI.Application.Abstractions.Behaviors;
    using PlantillaMicroAPI.Domain.Services;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBahavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddTransient<NombreEntidadService>();

            return services;
        }
    }
}
