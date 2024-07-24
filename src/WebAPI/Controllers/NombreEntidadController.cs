namespace PlantillaMicroAPI.WebAPI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using PlantillaMicroAPI.Application.Features.NombreEntidad.CommandEntidad;
    using PlantillaMicroAPI.Application.Features.NombreEntidad.QueryEntidadById;

    [ApiController]
    [Route("api/entidad")]
    public class NombreEntidadController : ControllerBase
    {
        private readonly IMediator mediator;

        public NombreEntidadController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntidad(int id, CancellationToken cancellationToken)
        {
            var query = new EntidadByIdQuery(id);
            var result = await this.mediator.Send(query, cancellationToken);

            return result.IsSuccess ? this.Ok(result.Data) : this.NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostEntidad([FromBody] object request, CancellationToken cancellationToken)
        {
            var command = new EntidadCommand(request);

            var result = await this.mediator.Send(command, cancellationToken);

            if (result?.IsFailure ?? true)
            {
                return this.BadRequest(result?.Error);
            }

            return this.Ok(result.Data);
        }
    }
}
