using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mod=Modelos;
using Negocio;
using WebFactura.Modelos;

namespace WebFactura.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFactura _factura = new Negocio.Factura();

        [HttpPost]
        public ActionResult<Response<mod.ResponseFactura>> ProcesarFactura(List<mod.Factura> facturas)
        {
            Response<mod.ResponseFactura> response = new Response<mod.ResponseFactura>();
            try
            {
               response.Entidad = _factura.ProcesarFactura(facturas);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }
        

    }
}
