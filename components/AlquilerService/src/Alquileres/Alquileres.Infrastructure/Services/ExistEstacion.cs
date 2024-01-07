
using Alquileres.Domain;
using Alquileres.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace Alquileres.Infrastructure.Repository.Services;

public class EstacionService : IEstacionService
{
    private readonly IHttpClientFactory _httpClientFactory;

    // TODO: Obtener la url de la api del archivo de  configuracion
    public EstacionService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }



    public async Task VerifyExistanceEstacion(AlquilerEstacionId id)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        const string url = "http://estaciones-service-dev:5048/api/v1/estaciones";

        var response = await httpClient.GetAsync($"{url}/{id.Value}");
        if (!response.IsSuccessStatusCode)
        {
            // TODO: Crear nueva exection
            throw new Exception($"no se pudo encontrar la estacion con id:{id.Value}, {response.Content}");
        }
        Console.WriteLine("Se encontro la estacion");

    }
}