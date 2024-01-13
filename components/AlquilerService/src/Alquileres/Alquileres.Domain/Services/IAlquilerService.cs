
using Alquileres.Domain.Estacion;
using Tarifas.Domain;

namespace Alquileres.Domain.Services;
public interface IAlquilerService
{
    AlquilerMonto CalcularMontoTotal(TimeSpan tiempoAlquiler, Tarifa tarifa, EstacionDistancia distanciaKm);
}