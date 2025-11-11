using System;

namespace Library
{
    /// <summary>
    /// Representa una interacción del tipo llamada dentro del sistema CRM.
    /// Hereda de <see cref="Interaccion"/> y agrega información sobre la duración de la llamada.
    /// </summary>
    public class Llamada : Interaccion
    {
        /// <summary>
        /// Duración total de la llamada (por ejemplo, "5 minutos", "00:03:45", etc.).
        /// </summary>
        public string Duracion { get; private set; }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase <see cref="Llamada"/>.
        /// </summary>
        /// <param name="fecha">Fecha en que se realizó la llamada.</param>
        /// <param name="descripcion">Descripción breve de la llamada.</param>
        /// <param name="notas">Notas adicionales asociadas a la llamada.</param>
        /// <param name="respondida">Indica si la llamada fue respondida.</param>
        /// <param name="direccion">Dirección o número de contacto del destinatario.</param>
        /// <param name="duracion">Duración total de la llamada.</param>
        public Llamada(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string duracion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Duracion = duracion;
        }

        /// <summary>
        /// Constructor vacío que permite crear una instancia sin inicializar los valores.
        /// </summary>
        public Llamada() : base() { }
    }
}