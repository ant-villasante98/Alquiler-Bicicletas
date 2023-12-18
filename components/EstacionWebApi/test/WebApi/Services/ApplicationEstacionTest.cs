using AutoMapper;
using Domain.Models;
using Domain.Services;
using WebApi.Request;
using WebApi.Response;
using WebApi.Services.Implement;
using WebApi.Utilities;

namespace ApplicationTest.Services;

public class AplicationEstacionTest
{
    [Fact]
    public async void GetAll_HaveToReturnAllEstaciones()
    {
        // Arrange
        var service = new Mock<IEstacionService>();
        var mapperConfiguration = new MapperConfiguration(
            cfg => cfg.AddProfile<AutoMapperProfile>()
        );
        var mapper = new Mapper(mapperConfiguration);

        long id1 = 23;
        long id2 = 42;
        Estacion est1 = new Estacion(id1, "Puente", DateTime.Now, 1.324, 6.234);
        Estacion est2 = new Estacion(id2, "Mar", DateTime.Now, 1.543, 6.0877);
        var listEstacion = new List<Estacion>() { est1, est2 };

        service.Setup(serv => serv.GetAll()).ReturnsAsync(listEstacion);

        var application = new ApplicationEstacion(service.Object, mapper);

        // Act
        var result = await application.GetAll();

        // Assert
        mapperConfiguration.AssertConfigurationIsValid();

        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count);
        Assert.DoesNotContain(result, (EstacionDto est) => est.Id == 21);

        Assert.Contains(result, (EstacionDto est) => est.Id == id1);
        Assert.Equal(est1.Nombre, result.First((est) => est.Id == id1).Nombre);
        Assert.Equal(est1.Longitud, result.First((est) => est.Id == id1).Longitud);
        Assert.Equal(est1.Latitud, result.First((est) => est.Id == id1).Latitud);

        Assert.Contains(result, (EstacionDto est) => est.Id == id2);
        Assert.Equal(est2.Nombre, result.First((est) => est.Id == id2).Nombre);
        Assert.Equal(est2.Longitud, result.First((est) => est.Id == id2).Longitud);
        Assert.Equal(est2.Latitud, result.First((est) => est.Id == id2).Latitud);
    }

    [Fact]
    public async void Create_HaveToCreateAEstacion()
    {
        // Arrange
        var service = new Mock<IEstacionService>();

        MapperConfiguration configuration = new MapperConfiguration(
            conf => conf.AddProfile<AutoMapperProfile>()
        );
        Mapper mapper = new Mapper(configuration);

        var estacion = new EstacionCreate("Puente", 64.342, 36.343);
        Estacion estacionEntity = It.IsAny<Estacion>();

        long exceptedId = 5;
        DateTime expectedDate = DateTime.Now;
        service
            .Setup(serv => serv.Create(It.IsAny<Estacion>()))
            .Callback(
                (Estacion est) =>
                {
                    estacionEntity = est;
                }
            )
            .ReturnsAsync(
                new Estacion(
                    exceptedId,
                    estacion.Nombre,
                    expectedDate,
                    estacion.Latitud,
                    estacion.Longitud
                )
            );

        var application = new ApplicationEstacion(service.Object, mapper);

        // Act
        EstacionDto result = await application.Create(estacion);

        // Assert
        Assert.NotNull(estacionEntity);
        Assert.NotNull(result);
        Assert.Equal(0, estacionEntity.Id);
        Assert.Equal(estacion.Nombre, estacionEntity.Nombre);
        Assert.Equal(estacion.Latitud, estacionEntity.Latitud);
        Assert.Equal(estacion.Longitud, estacionEntity.Longitud);

        Assert.Equal(estacion.Nombre, result.Nombre);
        Assert.Equal(estacion.Latitud, result.Latitud);
        Assert.Equal(estacion.Longitud, result.Longitud);
    }
}
