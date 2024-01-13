
using Alquileres.Application.Create;
using Alquileres.Domain;
using Alquileres.Domain.Services;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Alquileres.Application.Test.Create;

public class CreateAlquilerTest
{
    [Fact]
    public async void CerateToHaveANewAlquiler()
    {
        // Averrage
        var repository = new Mock<IAlquilerRepository>();
        var estacionService = new Mock<IEstacionService>();
        var tarifaService = new Mock<ITarifaService>();

        AlquilerId savedId = new(6);
        string cliente = Guid.NewGuid().ToString();
        AlquilerEstacionId estacionRetiro = new(12);
        Alquiler newAlquiler = Alquiler.StartAlquiler(
            cliente: cliente,
            estacionRetiro: estacionRetiro
        );

        Alquiler savedAlquiler = It.IsAny<Alquiler>();

        repository.Setup(
            r => r.AddAsync(It.IsAny<Alquiler>())
            ).Callback((Alquiler a) =>
            {
                savedAlquiler = new Alquiler(
                    id: savedId,
                    estado: a.Estado,
                    cliente: a.Cliente,
                    estacionRetiro: a.EstacionRetiro,
                    estacionDevolucion: a.EstacionDevolucion,
                    fechaHoraRetiro: a.FechaHoraRetiro,
                    fechaHoraDevolucion: a.FechaHoraDevolucion,
                    monto: a.Monto,
                    tarifaId: a.TarifaId,
                    tarifa: It.IsAny<Tarifa>()
                    );
            }).ReturnsAsync(
                It.IsAny<Alquiler>()
            );

        estacionService.Setup(
            s => s.VerifyExistanceEstacion(It.IsAny<AlquilerEstacionId>())
            );
        tarifaService.Setup(serv => serv.GetByFecha(It.IsAny<TarifaFecha>()))
            .ReturnsAsync(It.IsAny<Tarifa>());


        CreateAlquiler creator = new CreateAlquiler(repository.Object, estacionService.Object, tarifaService.Object);

        // Act
        var result = await creator.Create(cliente, estacionRetiro);

        // Assert
        estacionService.Verify(serv => serv.VerifyExistanceEstacion(estacionRetiro), Times.Once);
        repository.Verify(repo => repo.AddAsync(It.IsAny<Alquiler>()), Times.Once);
        tarifaService.Verify(serv => serv.GetByFecha(It.IsAny<TarifaFecha>()), Times.Once);
        Assert.NotNull(savedAlquiler.FechaHoraRetiro);
        Assert.Null(savedAlquiler.FechaHoraDevolucion);
        Assert.Null(savedAlquiler.Monto);
        Assert.Null(savedAlquiler.EstacionDevolucion);
        Assert.Equal(cliente, savedAlquiler.Cliente);
        Assert.Equal(estacionRetiro, savedAlquiler.EstacionRetiro);
        Assert.Equal(AlquilerEstado.Inicio, savedAlquiler.Estado);
    }
}