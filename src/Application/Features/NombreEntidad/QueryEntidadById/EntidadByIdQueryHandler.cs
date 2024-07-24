namespace PlantillaMicroAPI.Application.Features.NombreEntidad.QueryEntidadById
{
    using System.Threading;
    using System.Threading.Tasks;
    using PlantillaMicroAPI.Application.Abstractions.Messaging;
    using PlantillaMicroAPI.Domain.Abstractions;
    using PlantillaMicroAPI.Domain.NombreEntidad;

    public sealed class EntidadByIdQueryHandler : IQueryHandler<EntidadByIdQuery, EntidadByIdResponse>
    {
        public EntidadByIdQueryHandler(INombreEntidadRepository nombreEntidadRepository)
        {
            this.NombreEntidadRepository = nombreEntidadRepository;
        }

        private INombreEntidadRepository NombreEntidadRepository { get; }

        public async Task<Result<EntidadByIdResponse>> Handle(EntidadByIdQuery request, CancellationToken cancellationToken)
        {
            var entidad = await this.NombreEntidadRepository.GetByIdAsync(request.id);

            if (entidad is null)
            {
                return Result.Failure<EntidadByIdResponse>(Error.None);
            }

            // mapping que corresponda
            var entidadResponse = new EntidadByIdResponse(entidad.Id);

            return Result.Success(entidadResponse);
        }
    }
}
