
namespace Alquileres.Domain.Services;

public interface ICreateAlquiler
{
    Task<Alquiler> Create(string cliente, AlquilerEstacionId estacionRetiro);
}