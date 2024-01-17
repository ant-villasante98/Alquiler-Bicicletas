

namespace Estaciones.Application.Utility;

public class CalculadorDistcia
{
    private static readonly double RadioTierraKm = 6371;
    public static double CalcularDistancia(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino)
    {

        var dLat = ConvertirARadianes(latitudDestino - latitudOrigen);
        var dLon = ConvertirARadianes(longitudDestino - longitudOrigen);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ConvertirARadianes(latitudOrigen)) * Math.Cos(ConvertirARadianes(latitudDestino)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var distance = RadioTierraKm * c;
        return distance;
    }
    private static double ConvertirARadianes(double grados)
    {
        return grados * Math.PI / 180;
    }
}