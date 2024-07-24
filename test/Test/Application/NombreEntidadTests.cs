namespace Test.Application
{
    using Moq;
    using PlantillaMicroAPI.Application.Features.NombreEntidad.CommandEntidad;
    using PlantillaMicroAPI.Application.Features.NombreEntidad.QueryEntidadById;
    using PlantillaMicroAPI.Domain.Abstractions;
    using PlantillaMicroAPI.Domain.NombreEntidad;
    using PlantillaMicroAPI.Domain.Services;

    public class NombreEntidadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEntidadQueryHandler_Retorna_Success()
        {
            // Prepare
            var mockRepository = new Mock<INombreEntidadRepository>();

            var command = new EntidadByIdQuery(1);

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default)).ReturnsAsync(It.IsAny<NombreEntidad>);

            var handler = new EntidadByIdQueryHandler(mockRepository.Object);

            // Execute
            var resultado = handler.Handle(command, default);

            // Assert
            Assert.That(resultado.Result.IsSuccess, Is.True);
        }

        [Test]
        public void PostEntidadCommand_Input_Valido_Retorna_Success()
        {
            // Prepare
            var mockRepository = new Mock<INombreEntidadRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockNombreEntidadService = new Mock<NombreEntidadService>();

            var command = new EntidadCommand(new { propiedadDeLaEntidad = "valorDeLaPropiedad" });

            var entidad = new NombreEntidad();

            mockRepository.Setup(x => x.AddAsync(entidad)).Returns(It.IsAny<Task>);
            mockUnitOfWork.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(It.IsAny<int>).Verifiable();

            var handler = new EntidadCommandHandler(mockRepository.Object, mockNombreEntidadService.Object, mockUnitOfWork.Object);

            // Execute
            var resultado = handler.Handle(command, default);

            // Assert
            Assert.That(resultado.Result.IsSuccess, Is.True);
        }

        [Test]
        public void PostEntidadCommand_Input_Invalido_Retorna_Failure()
        {
            // Prepare
            var mockRepository = new Mock<INombreEntidadRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockNombreEntidadService = new Mock<NombreEntidadService>();

            var command = new EntidadCommand(null);

            var handler = new EntidadCommandHandler(mockRepository.Object, mockNombreEntidadService.Object, mockUnitOfWork.Object);

            // Execute
            var resultado = handler.Handle(command, default);

            // Assert
            Assert.That(resultado.Result.IsFailure, Is.True);
            Assert.That("INPUT_INVALIDO", Is.EqualTo(resultado.Result.Error.code));
        }
    }
}