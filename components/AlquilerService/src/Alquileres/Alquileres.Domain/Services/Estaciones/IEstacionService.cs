

using Alquileres.Domain.Estacion;

namespace Alquileres.Domain.Services;

public interface IEstacionService
{
    Task VerifyExistanceEstacion(AlquilerEstacionId id);
    Task GetById(AlquilerEstacionId id);
    Task<EstacionDistancia> CalculateDistance(AlquilerEstacionId estacionRetiro, AlquilerEstacionId estacionDevolucion);
}