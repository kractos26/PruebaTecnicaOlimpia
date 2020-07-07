using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilidad;
using Utilidad.Validaciones;
using mod = Modelos;
namespace Negocio
{
    public class Factura : IFactura
    {
        public ResponseFactura ProcesarFactura(List<mod.Factura> facturas)
        {
            mod.ResponseFactura responseFactura = new ResponseFactura();
            try
            {

                if (facturas.Count > 0)
                {
                    facturas.ForEach(itemfactura =>
                    {
                        itemfactura.Mensaje = Validar(itemfactura);
                        itemfactura.ValorIva = itemfactura.ValorTotal * (itemfactura.ValorIva / 100);
                    });
                    if (facturas.Where(x => x.Mensaje != string.Empty).Count() > 0)
                    {
                        responseFactura.Facturas = facturas;
                        throw new System.Exception("Las facturas presentaron algunos errores por favor rebice cada item detalladamente");
                    }
                    else
                    {
                        responseFactura.Facturas = facturas;
                        responseFactura.TotalIva = facturas.Sum(x => x.ValorIva);
                        responseFactura.TotalFacturas = facturas.Sum(x => x.ValorTotal);
                    }
                }
                else
                {
                    throw new System.Exception("No hay facturas por procesar");
                }
            }
            catch (System.Exception ex)
            {
                responseFactura.Mensaje = ex.Message;
                return responseFactura;
            }
            return responseFactura;

        }

        public string Validar(mod.Factura factura)
        {
            string mensaje = "";
            mensaje += $"La factura con id {factura.IdFactura} presenta los siguientes errores";
            mensaje += ValidarCampo.ValidarNumero(new Campo() { Contenido = factura.IdFactura, IsPositivo = true, Nombre = "id factura" }) + Environment.NewLine;
            mensaje += ValidarCampo.ValidarNumero(new Campo() { Contenido = factura.Nit, Nombre = "Nit factua" }) + Environment.NewLine;
            mensaje += ValidarCampo.ValidarNumero(new Campo() { Contenido = factura.ValorTotal, IsPositivo = true, Nombre = "Valor Total" }) + Environment.NewLine;
            mensaje += ValidarCampo.ValidarNumero(new Campo() { Contenido = factura.Iva, ValorMaximo = 100, ValorMinimo = 0, Nombre = "Valor del Iva" }) + Environment.NewLine;

            return mensaje;
        }


    }
}
