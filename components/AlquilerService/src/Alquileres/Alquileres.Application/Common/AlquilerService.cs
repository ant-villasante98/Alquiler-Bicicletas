
using Alquileres.Domain;
using Alquileres.Domain.Estacion;
using Alquileres.Domain.Services;
using Tarifas.Domain;

namespace Alquileres.Application.Common;

public class AlquilerService : IAlquilerService
{

    public AlquilerMonto CalcularMontoTotal(TimeSpan tiempoAlquilado, Tarifa tarifa, EstacionDistancia distanciaKm)
    {
        double montoHora = tiempoAlquilado.Hours * tarifa.MontoHora.Value;
        double montoKm = distanciaKm.Value * tarifa.MontoKm.Value;
        double montoFraccion = 0;
        if (tiempoAlquilado.Minutes >= 31)
        {
            montoFraccion += tiempoAlquilado.Minutes * tarifa.MontoMinutoFraccion.Value;
        }

        double montoTotal = tarifa.MontoFijoAlquiler.Value + montoHora + montoKm + montoFraccion;
        return new AlquilerMonto(montoTotal);
    }
}