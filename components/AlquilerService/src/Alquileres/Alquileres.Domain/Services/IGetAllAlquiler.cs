
namespace Alquileres.Domain.Services;

public interface IGetAllAlquiler
{
    Task<List<Alquiler>> GetAll();
}