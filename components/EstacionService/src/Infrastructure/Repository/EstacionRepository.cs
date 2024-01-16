using System.Linq.Expressions;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EstacionRepository : IEstacionRepository
{
    private readonly BicicletasBdaContext _context;

    public EstacionRepository(BicicletasBdaContext context)
    {
        _context = context;
    }
    public async Task<Estacion> FindOne(Expression<Func<Estacion, bool>> filter)
    {
        try
        {
            Estacion model = await _context.Set<Estacion>().FirstAsync(filter);
            return model;
        }
        catch (Exception)
        {
            throw new NullReferenceException($"No se puedo en contrar la Estacion");
        }
    }

    public async Task<Estacion> Add(Estacion model)
    {
        try
        {
            _context.Set<Estacion>().Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task Update(Estacion model)
    {
        try
        {
            _context.Set<Estacion>().Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task Delete(Estacion model)
    {
        try
        {
            _context.Set<Estacion>().Remove(model);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual async Task<Estacion> FindbyId(EstacionId id)
    {
        try
        {
            Estacion model =
                await _context.Set<Estacion>().FindAsync(id) ?? throw new NullReferenceException();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new KeyNotFoundException($"{typeof(Estacion)} no encontrado con el id: {id}");
        }
    }

    public virtual async Task<List<Estacion>> FindAll()
    {
        return await _context.Set<Estacion>().ToListAsync();
    }
}
