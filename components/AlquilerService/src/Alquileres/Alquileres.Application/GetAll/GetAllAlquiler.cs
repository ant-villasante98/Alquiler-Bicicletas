
using Alquileres.Domain;
using Alquileres.Domain.Services;

namespace Alquileres.Application.GetAll;

public class GetAllAlquiler : IGetAllAlquiler
{
    private readonly IAlquilerRepository _repository;

    public GetAllAlquiler(IAlquilerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Alquiler>> GetAll()
    {
        List<Alquiler> alquileres = await _repository.FindAllAsync();
        return alquileres;
    }
}