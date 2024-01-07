
namespace Alquileres.Domain.Services;

public interface IEstacionService
{
    Task VerifyExistanceEstacion(AlquilerEstacionId id);
}