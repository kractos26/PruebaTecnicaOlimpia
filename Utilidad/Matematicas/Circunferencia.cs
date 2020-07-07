

using System;

namespace Utilidad.Matematicas
{
    public class Circunferencia
    {
        /// <summary>
        /// Determina si dos circulos son secantes
        /// </summary>
        /// <param name="circuloa">Datos del primer circulo</param>
        /// <param name="circulob">Datos del segundo circulo</param>
        /// <returns></returns>
        public bool IsSecantes(Circulo circuloa, Circulo circulob)
        {
            try
            {
                Mathematica mathematica = new Mathematica();
                bool issecante = false;
                double distancia = mathematica.DistanciaDosPuntos(new Cordenada()
                { PuntoX = circuloa.CordenadaX, PuntoY = circuloa.CordenadaY }, new Cordenada()
                { PuntoX = circulob.CordenadaX, PuntoY = circulob.CordenadaY }
                  );
                issecante = (distancia < (circuloa.radio + circulob.radio) && distancia > Math.Abs(circuloa.radio - circulob.radio)) ? true : issecante;
                return issecante;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
