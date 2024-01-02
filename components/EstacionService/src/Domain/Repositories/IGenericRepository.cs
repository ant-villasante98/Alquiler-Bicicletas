using System.Linq.Expressions;

namespace Domain.Repositories;

public interface IGenericRepository<TModel, IdType>
    where TModel : class
{
    Task<TModel> FindOne(Expression<Func<TModel, bool>> filter);

    Task<TModel> Add(TModel model);

    Task Update(TModel model);

    Task Delete(TModel model);


    Task<TModel> FindbyId(IdType id);

    Task<List<TModel>> FindAll();
}
