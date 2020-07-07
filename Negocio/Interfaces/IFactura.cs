using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = Modelos;
namespace Negocio
{
    public interface IFactura
    {
        string Validar(mod.Factura factura);
        ResponseFactura ProcesarFactura(List<mod.Factura> facturas);
    }
}
