using System.Net.Http.Json;
using Alquileres.Domain;
using Alquileres.Domain.Estacion;
using Alquileres.Domain.Services;
using Shared.Domain.CustomExceptions;

namespace Alquileres.Infrastructure.Repository.Services;

public class EstacionService : IEstacionService
{
    private readonly string Url = "http://estaciones-service-dev:5048/api/v1/estaciones";
    private readonly IHttpClientFactory _httpClientFactory;

    // TODO: Obtener la url de la api del archivo de  configuracion
    public EstacionService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<EstacionDistancia> CalculateDistance(
        AlquilerEstacionId estacionRetiro,
        AlquilerEstacionId estacionDevolucion
    )
    {
        try
        {
            // TODO: manejar respuesta NotFound de la peticion
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<EstacionDistancia>(
                $"{Url}/calcular-distancia?origen={estacionRetiro.Value}&destino={estacionDevolucion.Value}"
            );
            if (response is null)
            {
                throw new NullReferenceException();
            }

            return response;
        }
        catch (NullReferenceException)
        {
            throw new NotFoundElementException("No se encontro la distacia");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task GetById(AlquilerEstacionId id)
    {
        throw new NotImplementedException();
    }

    public async Task VerifyExistanceEstacion(AlquilerEstacionId id)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();

        var response = await httpClient.GetAsync($"{Url}/{id.Value}");
        if (!response.IsSuccessStatusCode)
        {
            // TODO: Crear nueva exection
            throw new NotFoundElementException(
                $"no se pudo encontrar la estacion con id:{id.Value}, {response.Content}"
            );
        }
    }
}

