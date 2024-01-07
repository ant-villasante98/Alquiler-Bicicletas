
using Microsoft.EntityFrameworkCore;
using Tarifas.Domain;
using Tarifas.Domain.Repositories;
using Tarifas.Shared.Infrastructure.Persistence;

namespace Tarifas.Infrastructure;

public class TarifaRepository : ITarifaRepository
{
    private readonly AlquilerContext _context;

    public TarifaRepository(AlquilerContext context)
    {
        _context = context;
    }

    public async Task<Tarifa> Add(Tarifa tarifa)
    {
        _context.Tarifas.Add(tarifa);
        await _context.SaveChangesAsync();

        return tarifa;
    }

    public async Task Delete(Tarifa tarifa)
    {
        _context.Tarifas.Remove(tarifa);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Tarifa>> FindAll()
    {
        return await _context.Tarifas.ToListAsync();
    }

    public async Task<Tarifa> FindById(TarifaId id)
    {
        return await _context.Tarifas.FindAsync(id);
    }

    public async Task Update(Tarifa tarifa)
    {
        _context.Tarifas.Update(tarifa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}