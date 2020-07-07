using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidad.ManejoDocumento
{
    public class Archivo
    {
        /// <summary>
        /// Nombre de Archivo. 
        /// </summary>
        public string Nombre{ set; get; }
        /// <summary>
        /// tipo de archivo.
        /// </summary>
        public string Extension { set; get; }
    /// <summary>
    /// Arreglo de byte que contiene información del archivo.
    /// </summary>
        public byte[] Informacion { set; get; }
        public string Ruta { get; set; }
    }
}
