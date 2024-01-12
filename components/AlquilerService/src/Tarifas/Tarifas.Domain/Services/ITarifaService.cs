
namespace Tarifas.Domain.Services;

public interface ITarifaService
{
    Task<Tarifa> GetById(TarifaId id);
    Task<List<Tarifa>> GetAll();

    Task Delete(TarifaId id);

    Task Update(TarifaId id, int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora);

    Task<Tarifa> Create(int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora);

    Task<Tarifa> GetByFecha(TarifaFecha fecha);
}