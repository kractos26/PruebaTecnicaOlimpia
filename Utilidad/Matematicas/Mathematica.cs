using System;

namespace Utilidad.Matematicas
{
    /// <summary>
    /// Con elementos comunes para operaciones matematicas.
    /// </summary>
    public class Mathematica
    {
        /// <summary>
        /// Determinar la distancia de cordenadas
        /// </summary>
        /// <param name="puntoa">punto final</param>
        /// <param name="puntob">punto final</param>
        /// <returns>Distancia calculada</returns>
        public double DistanciaDosPuntos(Cordenada puntoa, Cordenada puntob)
        {
            double distancia = Math.Sqrt(Math.Pow(puntoa.PuntoX - puntob.PuntoX, 2) + Math.Pow(puntoa.PuntoY - puntob.PuntoY, 2));
            return distancia;
        }
    }
}
