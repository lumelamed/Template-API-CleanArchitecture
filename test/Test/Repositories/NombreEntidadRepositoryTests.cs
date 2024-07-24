namespace Test.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using PlantillaMicroAPI.Domain.NombreEntidad;
    using PlantillaMicroAPI.Infrastructure;
    using PlantillaMicroAPI.Infrastructure.Repositories;

    public class NombreEntidadRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetById_OnSuccess_Debe_Retornar_Entidad()
        {
            // Prepare
            const int fakeId = 1;

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestDB").Options;

            var dbContext = new ApplicationDbContext(dbContextOptions);

            var entidad = new NombreEntidad(fakeId);

            dbContext.Entidad.Add(entidad);

            dbContext.SaveChanges();

            var repository = this.CreateRepository(dbContext: dbContext);

            // Execute
            var result = repository.GetByIdAsync(fakeId);

            // Asserts
            Assert.True(result?.Result is not null);
            Assert.That(fakeId, Is.EqualTo(result!.Result!.Id));
        }

        protected NombreEntidadRepository CreateRepository(ApplicationDbContext dbContext = null)
        {
            dbContext = dbContext ?? new Mock<ApplicationDbContext>().Object;

            return new NombreEntidadRepository(dbContext);
        }
    }
}