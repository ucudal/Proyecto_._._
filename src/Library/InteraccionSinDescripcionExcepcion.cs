using System;

namespace Library
{
    /// <summary>
    /// Excepción personalizada que se lanza cuando se intenta crear o registrar
    /// una interacción sin descripción válida.
    /// </summary>
    public class InteraccionSinDescripcionException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la excepción con un mensaje personalizado.
        /// </summary>
        /// <param name="mensaje">Mensaje que describe el error.</param>
        public InteraccionSinDescripcionException(string mensaje) : base(mensaje)
        {
        }
    }
}