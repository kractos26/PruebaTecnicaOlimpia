namespace Utilidad.Validaciones
{
    /// <summary>
    /// clase propiedades generales de los campos
    /// </summary>
    public class Campo
    {
        /// <summary>
        /// Indica el tamaño del campo
        /// </summary>
        public int Longitud { get; set; }
        /// <summary>
        /// valor maximo del campo en caso de los campos tipo númerico.
        /// </summary>
        public double ValorMaximo { get; set; }
        /// <summary>
        /// valor minimo del campo en caso de los campos tipo númerico.
        /// </summary>
        public double ValorMinimo { get; set; }
        /// <summary>
        /// indica si permite que el campo este vacio.
        /// </summary>
        public bool IsNull { get; set; }
        /// <summary>
        /// Contiene la los datos.
        /// </summary>

        public object Contenido { get; set; }
        /// <summary>
        /// Permite caracteres especiale según su estado.
        /// </summary>
        public bool IsEpeciales { get; set; }
        /// <summary>
        /// Permite verificar si es un dia festivo.
        /// </summary>
        public bool IsHabil { get; set; }

        public string Nombre { get; set; }

        public bool IsPositivo { get; set; }
    }
}
