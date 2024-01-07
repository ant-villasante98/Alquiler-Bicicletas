

namespace Alquileres.Domain;

public interface IAlquilerRepository
{
    Task<Alquiler> AddAsync(Alquiler alquiler);
    Task UpdateAsync(Alquiler alquiler);

    Task<Alquiler> FindByIdAsync(AlquilerId id);
}