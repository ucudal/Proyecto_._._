using System;

namespace Library
{
    /// <summary>
    /// Representa un correo electrónico enviado o recibido como interacción con un cliente.
    /// Hereda de la clase Interaccion.
    /// </summary>
    public class Correo : Interaccion
    {
        /// <summary>
        /// Constructor que inicializa todas las propiedades de la interacción.
        /// </summary>
        /// <param name="fecha">Fecha de la interacción.</param>
        /// <param name="descripcion">Breve descripción del correo.</param>
        /// <param name="notas">Notas adicionales relacionadas con el correo.</param>
        /// <param name="respondida">Indica si la interacción fue respondida.</param>
        /// <param name="direccion">Dirección de correo asociada.</param>
        public Correo(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
        }

        /// <summary>
        /// Constructor vacío para permitir crear un objeto sin inicializar propiedades.
        /// Útil, por ejemplo, al usar GestorInteracciones.
        /// </summary>
        public Correo() : base() { }
    }
}