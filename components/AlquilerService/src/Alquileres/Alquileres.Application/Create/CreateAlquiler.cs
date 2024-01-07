
using Alquileres.Domain;
using Alquileres.Domain.Services;

namespace Alquileres.Application.Create;

public class CreateAlquiler : ICreateAlquiler
{
    private readonly IAlquilerRepository _repository;
    private readonly IEstacionService _existEstacion;

    public CreateAlquiler(IAlquilerRepository repository, IEstacionService existEstacion)
    {
        _repository = repository;
        _existEstacion = existEstacion;
    }

    public async Task<Alquiler> Create(string cliente, AlquilerEstacionId estacionRetiro)
    {
        await _existEstacion.VerifyExistanceEstacion(estacionRetiro);
        Alquiler alquiler = Alquiler.StartAlquiler(
            cliente: cliente,
            estacionRetiro: estacionRetiro
        );

        Alquiler savedAlquiler = await _repository.AddAsync(alquiler);

        return savedAlquiler;
    }
}