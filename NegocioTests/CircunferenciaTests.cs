using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos;
using Utilidad.Matematicas;
using Circulo = Utilidad.Matematicas.Circulo;

namespace Negocio.Tests
{
    [TestClass()]
    public class CircunferenciaTests
    {
        [TestMethod()]
        public void IsSecantesTest()
        {
            Circunferencia circunferencia = new Circunferencia();

            bool respuesta = circunferencia.IsSecantes(new Circulo()
            {
                CordenadaX = 3,
                CordenadaY = 4,
                radio = 5
            },

             new Circulo()
             {
                 CordenadaX = 10,
                 CordenadaY = 5,
                 radio = 8
             }
             );
            Assert.IsTrue(respuesta);
        }
    }
}