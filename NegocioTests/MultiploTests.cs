using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using Utilidad.ManejoDocumento;

namespace Negocio.Tests
{
    [TestClass()]
    public class MultiploTests
    {
        [TestMethod()]
        public void ValidarMultiplosTresTest()
        {
            Multiplo multiplo = new Multiplo();


            string prueba = "3333333333333333333333333333333333333333333333333333333333" + Environment.NewLine + "545454545454545454545454545454545454545454545454545454545454" + Environment.NewLine + "1234567891123456789212345678931234567894123456789";
            byte[] bytes = Encoding.ASCII.GetBytes(prueba);

           multiplo.ValidarMultiplosTres(new Archivo
           {
               Nombre = "Prueba2",
               Informacion = bytes,
               Extension = "txt"
           }
            );

        

            Assert.Fail();
        }
    }
}