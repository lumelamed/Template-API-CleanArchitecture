namespace PlantillaMicroAPI.Application.Features.NombreEntidad.QueryEntidadById
{
    using FluentValidation;

    public class EntidadByIdQueryValidator : AbstractValidator<EntidadByIdQuery>
    {
        public EntidadByIdQueryValidator()
        {
            this.RuleFor(c => c.id).GreaterThan(0);
        }
    }
}
