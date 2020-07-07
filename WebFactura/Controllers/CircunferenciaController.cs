using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using Utilidad.Matematicas;
using WebFactura.Modelos;

namespace WebFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircunferenciaController : ControllerBase
    {
        /// <summary>
        /// Permite determinar si dos circunferencias se crusan
        /// </summary>
        /// <param name="circuloa"></param>
        /// <param name="circulob"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Response<bool>> IsSecante(CircunferenciaModelo circunferencias)
        {
            Response<bool> response = new Response<bool>();
            Circunferencia circunferencia = new Circunferencia();
            response.Entidad = circunferencia.IsSecantes(circunferencias.Circuloa, circunferencias.Circulob);
            return Ok(response);

        }


    }
}
