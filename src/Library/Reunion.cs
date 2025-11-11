using System;

namespace Library
{
    /// <summary>
    /// Representa una reunión como tipo de interacción.
    /// Hereda de la clase base Interaccion.
    /// </summary>
    public class Reunion : Interaccion
    {
        /// <summary>
        /// Lugar donde se realiza la reunión.
        /// </summary>
        public string Lugar { get; private set; }

        /// <summary>
        /// Constructor que inicializa una reunión con todos los datos.
        /// </summary>
        /// <param name="fecha">Fecha de la reunión.</param>
        /// <param name="descripcion">Descripción breve de la reunión.</param>
        /// <param name="notas">Notas adicionales sobre la reunión.</param>
        /// <param name="respondida">Indica si la interacción fue respondida.</param>
        /// <param name="direccion">Dirección asociada a la reunión.</param>
        /// <param name="lugar">Lugar específico de la reunión.</param>
        public Reunion(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string lugar)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Lugar = lugar;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Reunion() : base() { }

        /// <summary>
        /// Indica si la reunión es próxima comparando con la fecha actual.
        /// </summary>
        /// <returns>true si la reunión aún no ha ocurrido; false si ya pasó.</returns>
        public bool EsProxima()
        {
            return Fecha > DateTime.Now;
        }
    }
}