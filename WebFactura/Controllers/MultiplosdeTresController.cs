using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Utilidad.ManejoDocumento;

namespace PresentacionNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplosdeTresController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult> MultiplosAsync(IFormFile files)
        {

            try
            {
                string ruta = ProcesarArchivo(files);

                if (ruta == null)
                    return Content("nombre del archivo no presente");

                MemoryStream memory = new MemoryStream();
                using (var stream = new FileStream(ruta, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(ruta), Path.GetFileName(ruta));

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }


        private string ProcesarArchivo(IFormFile files)
        {
            Multiplo multiplo = new Multiplo();
            var path = Path.Combine(
                 Directory.GetCurrentDirectory(), "Recursos",
                 files.FileName
                 );

            using (var stream = new FileStream(path, FileMode.Create))
            {
                files
.CopyTo(stream);
            }

            string respuests = multiplo.ValidarMultiplosTres(new Archivo()
            {
                Nombre = "respuesta",
                Ruta = Path.Combine(Directory.GetCurrentDirectory(), "Recursos"),
                Informacion = FileToByte(files),
                Extension = files.FileName.Split('.')[1]

            });

            return respuests;
        }
        private static byte[] FileToByte(IFormFile item)
        {
            byte[] data;
            var path = Path.Combine(
               Directory.GetCurrentDirectory(), "Recursos",
               item.FileName
               );
            using (Stream inputStream = new FileStream(path, FileMode.Open))
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }

                data = memoryStream.ToArray();
                return data;
            }
        }
    }
}