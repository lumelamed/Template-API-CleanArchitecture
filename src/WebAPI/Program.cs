namespace PlantillaMicroAPI.WebAPI
{
    using PlantillaMicroAPI.Application;
    using PlantillaMicroAPI.Infrastructure;
    using PlantillaMicroAPI.WebAPI.Extensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // desde ApplicationBuilderExtensions
            app.ApplyMigration();
            app.UseCustomExceptionHandler(); // excepciones a nivel aplicación

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}