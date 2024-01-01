using System.Linq.Expressions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GenericRepository<TModel, IdType> : IGenericRepository<TModel, IdType>
    where TModel : class
{
    //private readonly ServinformContext _context;
    private readonly DbContext _context;

    public GenericRepository(DbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<TModel> FindOne(Expression<Func<TModel, bool>> filter)
    {
        try
        {
            TModel model = await _context.Set<TModel>().FirstAsync(filter);
            return model;
        }
        catch (Exception)
        {
            throw new NullReferenceException($"No se puedo en contrar la Estacion");
        }
    }

    public async Task<TModel> Add(TModel model)
    {
        try
        {
            _context.Set<TModel>().Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task Update(TModel model)
    {
        try
        {
            _context.Set<TModel>().Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task Delete(TModel model)
    {
        try
        {
            _context.Set<TModel>().Remove(model);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

   //private IQueryable<TModel> Query(Expression<Func<TModel, bool>> filter = null!)
   //{
   //    try
   //    {
   //        IQueryable<TModel> queryModel =
   //            filter == null ? _context.Set<TModel>() : _context.Set<TModel>().Where(filter);
   //        return queryModel;
   //    }
   //    catch (Exception)
   //    {
   //        throw;
   //    }
   //}

    public virtual async Task<TModel> FindbyId(IdType id)
    {
        try
        {
            TModel model =
                await _context.Set<TModel>().FindAsync(id) ?? throw new NullReferenceException();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new KeyNotFoundException($"{typeof(TModel)} no encontrado con el id: {id}");
        }
    }

    public virtual async Task<List<TModel>> FindAll()
    {
        return await _context.Set<TModel>().ToListAsync();
    }
}
