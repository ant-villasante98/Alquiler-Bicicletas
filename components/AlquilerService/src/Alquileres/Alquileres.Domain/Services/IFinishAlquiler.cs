
namespace Alquileres.Domain.Services;

public interface IFinishAlquiler
{
    Task Finish(AlquilerId id, AlquilerEstacionId estacionId);
}