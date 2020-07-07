namespace Modelos
{
    public class Factura : Error
    {
        public int IdFactura { get; set; }
        public int Nit { get; set; }
        public decimal ValorTotal { get; set; }
        public int Iva { get; set; }
        public decimal ValorIva { get; set; }
    }
}
