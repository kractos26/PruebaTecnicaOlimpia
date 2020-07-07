using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidad.ManejoDocumento;

namespace Negocio
{
    public class Multiplo
    {
        /// <summary>
        /// Permite validar si la sumatoria de los digitos de cada linea son multiplos de 3
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public string ValidarMultiplosTres(Archivo archivo)
        {
            try
            {
                ManejoArchivo manejoArchivo = new ManejoArchivo();
                string respuesta = "";
                string contenido = archivo.Informacion.ToList().Count() > 0 ? Encoding.UTF8.GetString(archivo.Informacion).Trim() : "";
                List<string> rows = contenido.Split(Environment.NewLine.ToCharArray()).ToList();
                rows = rows.Where(val => !string.IsNullOrWhiteSpace(val)).ToList();

                rows.ForEach(item =>
                {
                    int valor = item.ToCharArray().ToList().Sum(x => (int)x);

                    respuesta += (valor % 3 == 0) ? $"{item} SI" : $"{item} NO";
                    respuesta += Environment.NewLine;
                });

                manejoArchivo.GuardarArchivo(new Archivo()
                {
                    Nombre = "respuesta",
                    Informacion = Encoding.ASCII.GetBytes(respuesta),
                    Extension = "txt",
                    Ruta = archivo.Ruta
                });

                return System.IO.Path.Combine( archivo.Ruta,"respuesta.txt");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
