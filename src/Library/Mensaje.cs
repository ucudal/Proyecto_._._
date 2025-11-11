using System;

namespace Library
{
    /// <summary>
    /// Representa una interacción del tipo mensaje dentro del sistema CRM.
    /// Hereda de <see cref="Interaccion"/> e incluye información adicional sobre el medio del mensaje.
    /// </summary>
    public class Mensaje : Interaccion
    {
        /// <summary>
        /// Medio por el cual se envió el mensaje (por ejemplo, "WhatsApp", "SMS", "Telegram", etc.).
        /// </summary>
        public string Medio { get; private set; }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase <see cref="Mensaje"/>.
        /// </summary>
        /// <param name="fecha">Fecha en que se realizó la interacción.</param>
        /// <param name="descripcion">Descripción breve del mensaje.</param>
        /// <param name="notas">Notas adicionales asociadas al mensaje.</param>
        /// <param name="respondida">Indica si el mensaje fue respondido.</param>
        /// <param name="direccion">Dirección o contacto relacionado con el mensaje.</param>
        /// <param name="medio">Medio de comunicación utilizado.</param>
        public Mensaje(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string medio)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Medio = medio;
        }

        /// <summary>
        /// Constructor vacío que permite crear una instancia sin inicializar los valores.
        /// </summary>
        public Mensaje() : base() { }
    }
}