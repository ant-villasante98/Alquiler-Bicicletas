
using Alquileres.Domain;
using Microsoft.EntityFrameworkCore;
using Tarifas.Domain;
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

    public async Task<List<Alquiler>> FindAllAsync()
    {
        return await _context.Alquileres.ToListAsync();
    }

    public async Task<Alquiler> FindByIdAsync(AlquilerId id)
    {
        return await _context.Alquileres.Include(alq => alq.Tarifa).FirstOrDefaultAsync(alq => alq.Id.Equals(id));
    }

    public async Task UpdateAsync(Alquiler alquiler)
    {
        _context.Alquileres.Update(alquiler).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}