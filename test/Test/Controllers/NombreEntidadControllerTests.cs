namespace Test.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using PlantillaMicroAPI.Application.Features.NombreEntidad.QueryEntidadById;
    using PlantillaMicroAPI.Domain.Abstractions;
    using PlantillaMicroAPI.WebAPI.Controllers;

    public class NombreEntidadControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public async void GetEntidad_Success_Returns_Success()
        {
            // Prepare
            var mediatorMock = new Mock<IMediator>();

            var mockResultado = Result.Success(new EntidadByIdResponse(1));

            mediatorMock.Setup(x => x.Send(It.IsAny<EntidadByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockResultado);

            var controller = new NombreEntidadController(mediatorMock.Object);

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Execute
            // var result = await controller.GetEntidad(1, default);

            // Assert
            // Verificar el HTTP Status Code, y si IsSuccess nuestra respuesta
            // Assert.True();
        }
    }
}