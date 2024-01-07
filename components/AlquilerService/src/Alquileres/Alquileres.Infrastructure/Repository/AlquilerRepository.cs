
using Alquileres.Domain;
using Tarifas.Shared.Infrastructure.Persistence;

namespace Alquileres.Infrastructure.Repository;

public class AlquilerRepository : IAlquilerRepository
{
    private readonly AlquilerContext _context;

    public AlquilerRepository(AlquilerContext context)
    {
        _context = context;
    }

    public async Task<Alquiler> AddAsync(Alquiler alquiler)
    {
        _context.Alquileres.Add(alquiler);
        await _context.SaveChangesAsync();
        return alquiler;
    }

    public Task<Alquiler> FindByIdAsync(AlquilerId id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Alquiler alquiler)
    {
        throw new NotImplementedException();
    }
}