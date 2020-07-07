namespace Utilidad.Validaciones
{     using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Nager.Date;
    using Nager.Date.Model;

/// <summary>
/// clase para la validación general de los campos
/// </summary>
    public class ValidarCampo
    {
        /// <summary>
        /// Valida la informacion de los campos tipo cadena.
        /// </summary>
        /// <param name="campo">contenido y información del campo.</param>
        /// <returns>Mensaje de error.</returns>
        public static string ValidarString(Campo campo)
        {
            string mensaje = string.Empty;
            string info = (campo.Contenido != null) ? campo.Contenido.ToString().Trim() : string.Empty;
            var texto = string.IsNullOrWhiteSpace(info) ? string.Empty : info;
            texto = Regex.Replace(texto, @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a - zA - ZÀ - ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", string.Empty, RegexOptions.None);
            mensaje += (campo.IsNull == false && string.IsNullOrWhiteSpace(info)) ? $"El campo {campo.Nombre} no debe estar vacio.{Environment.NewLine}" : string.Empty;
            mensaje += (info.Length > campo.Longitud) ? $"El tamaño maximo del campo {campo.Nombre} es de {campo.Longitud}. {Environment.NewLine}" : string.Empty;
            mensaje += (campo.IsEpeciales && !info.Equals(texto)) ? $"No se permite caracteres especiales en campo {campo.Nombre}. {Environment.NewLine}" : string.Empty;
            return mensaje;
        }

        /// <summary>
        /// Valida la informacion de los campos tipo numerico.
        /// </summary>
        /// <param name="campo">contenido y información del campo.</param>
        /// <returns>Mensaje de error.</returns>
        static public string ValidarNumero(Campo campo)
        {
            double numerico = 0;
            string mensaje = string.Empty;
            double.TryParse(campo.Contenido.ToString(), out numerico);
            mensaje += (numerico == 0) ? "El campo solo debe contener numeros 0 al 9" : string.Empty;
            mensaje += (numerico != 0 && numerico > campo.ValorMaximo) ? $"El valor maximo que se permite es {campo.ValorMaximo}. {Environment.NewLine}" : string.Empty;
            mensaje += (numerico != 0 && numerico < campo.ValorMinimo) ? $"El valor minimo que se permite es {campo.ValorMinimo}. {Environment.NewLine}" : string.Empty;
            return mensaje;
        }

        /// <summary>
        /// Valida la si elcampo es de tipo fecha
        /// </summary>
        /// <param name="campo">Contenido y información del campo..</param>
        /// <returns>Mensaje de error.</returns>
        static public string ValidarFecha(Campo campo)
        {
            string mensaje = string.Empty;
            DateTime fecha = default(DateTime);
            bool isFecha = DateTime.TryParse(campo.Contenido.ToString(), out fecha);
            mensaje += (!isFecha) ? $"El campo solo debe ser de tipo fecha {Environment.NewLine}" : string.Empty;

            mensaje += (isFecha && (DateSystem.IsPublicHoliday(fecha, CountryCode.CO) || DateSystem.IsWeekend(fecha, CountryCode.CO)) && campo.IsHabil) ? $"La {campo.Nombre} que ingresó no es un día hábil. {Environment.NewLine} " : string.Empty;
            return mensaje;
        }

    }
}
