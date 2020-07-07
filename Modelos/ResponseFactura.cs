using System.Collections.Generic;

namespace Modelos
{
    public class ResponseFactura : Error
    {
        public List<Factura> Facturas { get; set; }
        public decimal TotalFacturas { get; set; }
        public decimal TotalIva { get; set; }

    }
}
