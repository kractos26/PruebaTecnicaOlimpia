using System.Net;

namespace WebFactura.Modelos
{
    /// <summary>
    /// Clase para el manejo de las respustas
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public T Entidad { get; set; }
        public string mensaje { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
