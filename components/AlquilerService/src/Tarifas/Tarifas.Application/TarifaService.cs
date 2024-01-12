using Tarifas.Domain;
using Tarifas.Domain.Repositories;
using Tarifas.Domain.Services;

namespace Tarifas.Application;
public class TarifaService : ITarifaService
{
    private readonly ITarifaRepository _repository;

    public TarifaService(ITarifaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Tarifa> Create(int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora)
    {
        Tarifa tarifa = Tarifa.Create(tipoTarifa, definicion, diaSemana, fecha, montoFijoAlquiler, montoMinutoFraccion, montoKm, montoHora);
        Tarifa savedTarifa = await _repository.Add(tarifa);
        return savedTarifa;
    }

    public async Task Delete(TarifaId id)
    {
        Tarifa tarifa = await this.GetById(id);

        await _repository.Delete(tarifa);
    }

    public async Task<List<Tarifa>> GetAll()
    {
        return await _repository.FindAll();
    }

    public async Task<Tarifa> GetByFecha(TarifaFecha fecha)
    {
        Tarifa tarifa = await _repository.FindByFecha(fecha);
        return tarifa;
    }

    public async Task<Tarifa> GetById(TarifaId id)
    {
        return await _repository.FindById(id);
    }

    public async Task Update(TarifaId id, int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora)
    {
        Tarifa tarifa = await this.GetById(id);
        tarifa.Update(
            tipoTarifa,
            definicion,
            diaSemana,
            fecha,
            montoFijoAlquiler,
            montoMinutoFraccion,
            montoKm,
            montoHora
        );
        await _repository.Update(tarifa);
    }
}
