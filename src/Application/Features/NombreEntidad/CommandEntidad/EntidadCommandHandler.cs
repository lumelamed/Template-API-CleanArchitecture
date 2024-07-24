namespace PlantillaMicroAPI.Application.Features.NombreEntidad.CommandEntidad
{
    using System.Threading;
    using System.Threading.Tasks;
    using PlantillaMicroAPI.Application.Abstractions.Messaging;
    using PlantillaMicroAPI.Domain.Abstractions;
    using PlantillaMicroAPI.Domain.NombreEntidad;
    using PlantillaMicroAPI.Domain.Services;

    public sealed class EntidadCommandHandler : ICommandHandler<EntidadCommand, int>
    {
        private readonly INombreEntidadRepository nombreEntidadRepository;

        private readonly NombreEntidadService entidadService;

        private readonly IUnitOfWork unitOfWork;

        public EntidadCommandHandler(
            INombreEntidadRepository nombreEntidadRepository,
            NombreEntidadService entidadService,
            IUnitOfWork unitOfWork)
        {
            this.nombreEntidadRepository = nombreEntidadRepository;
            this.entidadService = entidadService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(EntidadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = ValidateInputModel(request);

                if (errors is not null && errors.Any())
                {
                    return Result.Failure<int>(new Error("INPUT_INVALIDO", errors.First()));
                }

                // utilizando los parametros del request
                var entidad = new NombreEntidad();

                // podría hacerse algo con la entidadService acá
                await this.nombreEntidadRepository.AddAsync(entidad);

                await this.unitOfWork.SaveChangesAsync(cancellationToken);

                return entidad.Id;
            }
            catch (Exception ex)
            {
                return Result.Failure<int>(Error.None);
            }
        }

        // en realidad está el Validator para esto, pero tal vez se quieren hacer validaciones más específicas
        protected static List<string> ValidateInputModel(EntidadCommand command)
        {
            var messages = new List<string>();

            if (command.parametros is null)
            {
                messages.Add("El parámetro ... no puede estar vacío");
            }

            return messages;
        }
    }
}
