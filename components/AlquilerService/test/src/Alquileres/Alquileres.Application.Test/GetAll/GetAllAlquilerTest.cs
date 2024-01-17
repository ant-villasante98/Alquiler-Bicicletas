
using Alquileres.Application.GetAll;
using Alquileres.Domain;
using Shared.Domain.Services;

namespace Alquileres.Application.Test.GetAll;

public class GetAllAlquilerTest
{
    [Fact]
    public async void GetAllHaveToAllAlquiler()
    {
        // Arrange
        var repository = new Mock<IAlquilerRepository>();
        var cache = new Mock<IDistributedCacheService>();

        List<Alquiler> alquileres = new List<Alquiler>{
            It.IsAny<Alquiler>(),
            It.IsAny<Alquiler>(),
            It.IsAny<Alquiler>(),
            It.IsAny<Alquiler>()
        };

        repository.Setup(rep => rep.FindAllAsync())
            .ReturnsAsync(alquileres);

        GetAllAlquiler getAll = new GetAllAlquiler(repository.Object, cache.Object);

        // Act
        List<Alquiler> response = await getAll.GetAll();

        // Assert
        Assert.NotEmpty(response);
        Assert.Equal(4, response.Count);
    }
}