
using System.Net;
using Alquileres.Application.Common;
using Alquileres.Domain;
using Alquileres.Domain.Estacion;
using Tarifas.Domain;
using Xunit.Sdk;

namespace Alquileres.Application.Test.Common;

public class AlquilerServiceTest
{
    [Fact]
    public void CalcularMontoTotalToHaveReturnAAlquilerMonto()
    {
        // Arrange
        TimeSpan tiempoAlquilado = new TimeSpan(3, 30, 0);
        Tarifa tarifa = new Tarifa(
            new TarifaId(9),
            2,
            'C',
            new TarifaDiaSemana(5),
            It.IsAny<TarifaFecha>(),
            new TarifaMonto(200.7),
            new TarifaMonto(5),
            new TarifaMonto(10),
            new TarifaMonto(2.3)
        );
        EstacionDistancia estacionDistancia = new(20);
        AlquilerMonto montoExpected = new AlquilerMonto(407.6);

        AlquilerService service = new AlquilerService();

        // Act
        AlquilerMonto response = service.CalcularMontoTotal(tiempoAlquilado, tarifa, estacionDistancia);

        // Assert
        Assert.Equal(montoExpected, response);
    }
}
