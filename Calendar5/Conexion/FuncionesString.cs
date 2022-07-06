using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace Calendar5.Conexion
{
    public static class FuncionesString
    {

        /// <summary>
        /// Función que permite formatear un texto antes de ser enviado para procesar.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string FormatearStringConsulta(string texto)
        {
            texto = texto.ToUpper();
            string[] valorinicial = { "Á", "É", "Í", "Ó", "Ú", "'", "\"", "%", "\\", "/", "*", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] valorfinal = { "A", "E", "I", "O", "U", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            texto = ReemplazarVariasLetras(valorinicial, valorfinal, texto);
            return texto;
        }

        /// <summary>
        /// Permite reemplazar varios caracteres de una cadena de texto, empleando dos arrays de caracteres.
        /// Creado: 2017-05-20
        /// </summary>
        /// <param name="caracteresacambiar">Caracteres a buscar y que serán reemplazados en la cadena</param>
        /// <param name="valoresnuevos">Caracteres nuevos.</param>
        /// <param name="cadena">Cadena de texto en la que se reemplazar los caracteres.</param>
        /// <returns>Cadena con los caracteres reemplazadas.</returns>
        public static string ReemplazarVariasLetras(string[] caracteresacambiar, string[] valoresnuevos, string cadena)
        {
            // Validar que ambas cadenas tengan el mismo tamano
            if (caracteresacambiar.GetLength(0) == valoresnuevos.GetLength(0))
            {
                for (int i = 0; i < caracteresacambiar.GetLength(0); i++)
                {
                    cadena = cadena.Replace(caracteresacambiar[i], valoresnuevos[i]);
                }
            }
            else
            {
                throw new Exception("Los arreglos no tienen la misma cantidad de elementos.");
            }
            return cadena;
        }

        /// <summary>
        /// Función que permite encriptar texto. Indispensable para el manejo de las contraseñas.
        /// </summary>
        /// <param name="texto">Texto a encriptar.</param>
        /// <returns></returns>
        public static string EncriptarTexto(string texto)
        {
            try
            {
                MD5 md5hash = MD5.Create();
                byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new FuncionesStringException("Error al tratar de encriptar. " + ex.Message);
            }
        }

        /// <summary>
        /// Función que lee un string y devuelve una fecha. La fecha debe estar en el formato dd/mm/aaa
        /// o de lo contrario devolvera una excepcón.
        /// </summary>
        /// <param name="fecha">Texto que contiene la fecha a convertir.</param>
        /// <returns></returns>
        public static DateTime ConvertirStringAFecha(string fecha)
        {
            try
            {
                string[] fechaarray = fecha.Split('/');
                if (fechaarray.Length == 3)
                {
                    int dia = Int32.Parse(fechaarray[0]);
                    int mes = Int32.Parse(fechaarray[1]);
                    int año = Int32.Parse(fechaarray[2]);
                    return new DateTime(año, mes, dia);
                }
                else
                {
                    throw new FuncionesStringException("No se reconoce el formato de la fecha. El formato debe ser dd/mm/aaaa.");
                }
            }
            catch (Exception ex)
            {
                throw new FuncionesStringException("No se reconoce el formato de la fecha. El formato debe ser dd/mm/aaaa. " + ex.Message);
            }
        }

        public class FuncionesStringException : Exception
        {
            public FuncionesStringException(string mensaje)
                : base(mensaje)
            {
            }
        }
    }
}