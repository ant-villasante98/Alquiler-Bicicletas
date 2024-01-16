
using Application.Utility;

namespace ApplicationTest.Utility;
public class CalculadorDistanciaTest
{
    [Fact]
    public void CalcularDistanciaToHaveReturnDistanciaKm()
    {
        // Arrange
        double latitudOrigen = 40.748817;
        double longitudOrigen = -73.985428;
        double latitudDestino = 34.052235;
        double longitudDestino = -118.243683;

        double expectedDistancia = 3941.01;
        double porcentajeError = 0.005;

        // Act 
        double result = CalculadorDistcia.CalcularDistancia(latitudOrigen, longitudOrigen, latitudDestino, longitudDestino);

        // Assert
        Assert.InRange(result, expectedDistancia - result * porcentajeError, expectedDistancia + result * porcentajeError);
    }

    [Fact]
    public void CalcularDistanciaToHaveReturnDistanciaKm2()
    {
        // Arrange
        double latitudOrigen = 37.774929;
        double longitudOrigen = -122.419416;
        double latitudDestino = 34.052235;
        double longitudDestino = -118.243683;

        double expectedDistancia = 559.66;
        double porcentajeError = 0.005;

        // Act 
        double result = CalculadorDistcia.CalcularDistancia(latitudOrigen, longitudOrigen, latitudDestino, longitudDestino);

        // Assert
        Assert.InRange(result, expectedDistancia - result * porcentajeError, expectedDistancia + result * porcentajeError);
    }
}