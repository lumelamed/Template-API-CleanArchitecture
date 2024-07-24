namespace PlantillaMicroAPI.Infrastructure.CoreServices
{
    using PlantillaMicroAPI.Application.Abstractions.CoreServices;

    internal sealed class CoreService : ICoreService
    {
        public Task FuncionAsync(string parametro)
        {
            // reemplazar con lógica de un servicio cross api
            return Task.CompletedTask;
        }
    }
}
