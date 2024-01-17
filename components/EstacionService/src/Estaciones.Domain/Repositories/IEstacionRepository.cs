using System.Linq.Expressions;
using Estaciones.Domain.Models;

namespace Estaciones.Domain.Repositories;

public interface IEstacionRepository
{
    Task<Estacion> FindOne(Expression<Func<Estacion, bool>> filter);

    Task<Estacion> Add(Estacion model);

    Task Update(Estacion model);

    Task Delete(Estacion model);


    Task<Estacion> FindbyId(EstacionId id);

    Task<List<Estacion>> FindAll();

}
