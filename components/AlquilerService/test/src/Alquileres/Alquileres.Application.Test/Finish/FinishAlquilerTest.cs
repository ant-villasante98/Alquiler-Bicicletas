
using Alquileres.Application.Finish;
using Alquileres.Domain;
using Alquileres.Domain.Estacion;
using Alquileres.Domain.Services;
using Tarifas.Domain;

namespace Alquileres.Application.Test.Finish;

public class FinishAlquilerTest
{
    [Fact]
    public async void FinishToDoFinishAlquiler()
    {
        // Arrange
        var repository = new Mock<IAlquilerRepository>();
        var estacionService = new Mock<IEstacionService>();
        var alquilerService = new Mock<IAlquilerService>();

        AlquilerId alquilerId = new AlquilerId(4);
        string cliente = Guid.NewGuid().ToString();
        AlquilerEstacionId estacionRetiro = new AlquilerEstacionId(3);
        AlquilerEstacionId estacionDevolucion = new AlquilerEstacionId(9);
        Alquiler alquiler = new(
            id: alquilerId,
            cliente: cliente,
            estacionRetiro: estacionRetiro,
            estado: AlquilerEstado.Inicio,
            fechaHoraRetiro: new AlquilerFechaRetiro(DateTime.UtcNow),
            estacionDevolucion: null,
            fechaHoraDevolucion: null,
            monto: null,
            tarifaId: new TarifaId(4),
            tarifa: It.IsAny<Tarifa>()
        );
        AlquilerMonto alquilerMonto = new(837.2);
        Alquiler savedAlquiler = It.IsAny<Alquiler>();


        repository.Setup(rep => rep.FindByIdAsync(alquilerId))
            .ReturnsAsync(alquiler);
        estacionService.Setup(serv => serv.CalculateDistance(estacionRetiro, estacionDevolucion))
            .ReturnsAsync(new EstacionDistancia(2.3));
        repository.Setup(rep => rep.UpdateAsync(alquiler))
            .Callback((Alquiler alq) =>
            {
                savedAlquiler = new Alquiler(
                    alq.Id,
                    alq.Estado,
                    alq.Cliente,
                    alq.EstacionRetiro,
                    alq.EstacionDevolucion,
                    alq.FechaHoraRetiro,
                    alq.FechaHoraDevolucion,
                    alq.Monto,
                    alq.TarifaId,
                    alq.Tarifa
                );
            });
        alquilerService.Setup(alqServ => alqServ.CalcularMontoTotal(It.IsAny<TimeSpan>(), It.IsAny<Tarifa>(), It.IsAny<EstacionDistancia>()))
            .Returns(alquilerMonto);

        FinishAlquiler finisher = new FinishAlquiler(repository.Object, estacionService.Object, alquilerService.Object);

        // Act
        await finisher.Finish(alquilerId, estacionDevolucion);

        // Assert
        repository.Verify(rep => rep.UpdateAsync(alquiler), Times.Once);
        repository.Verify(rep => rep.FindByIdAsync(alquilerId), Times.Once);
        estacionService.Verify(estServ => estServ.CalculateDistance(alquiler.EstacionRetiro, estacionDevolucion), Times.Once);
        Assert.Equal(alquilerId, savedAlquiler.Id);
        Assert.Equal(estacionDevolucion, savedAlquiler.EstacionDevolucion);
        Assert.Equal(alquilerMonto, savedAlquiler.Monto);
    }
}