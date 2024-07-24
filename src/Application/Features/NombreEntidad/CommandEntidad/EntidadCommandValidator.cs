namespace PlantillaMicroAPI.Application.Features.NombreEntidad.CommandEntidad
{
    using FluentValidation;

    public class EntidadCommandValidator : AbstractValidator<EntidadCommand>
    {
        public EntidadCommandValidator()
        {
            this.RuleFor(c => c.parametros).NotEmpty();
        }
    }
}
