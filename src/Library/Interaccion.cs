using System;

namespace Library
{
    /// <summary>
    /// Clase base abstracta que representa una interacción genérica con un cliente,
    /// como una llamada, correo, mensaje, reunión, etc.
    /// </summary>
    public abstract class Interaccion
    {
        /// <summary>
        /// Identificador único de la interacción.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha en la que ocurrió la interacción.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Breve descripción del contenido o propósito de la interacción.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Notas adicionales o detalles de la interacción.
        /// </summary>
        public string Notas { get; set; }

        /// <summary>
        /// Indica si la interacción fue respondida o no.
        /// </summary>
        public bool Respondida { get; set; }

        /// <summary>
        /// Dirección o ubicación asociada a la interacción.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Constructor protegido: inicializa los valores principales de la interacción.
        /// </summary>
        protected Interaccion(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new InteraccionSinDescripcionException("La descripción de la interacción no puede estar vacía.");

            Fecha = fecha;
            Descripcion = descripcion;
            Notas = notas;
            Respondida = respondida;
            Direccion = direccion;
        }

        /// <summary>
        /// Constructor vacío: permite crear una interacción sin parámetros (por ejemplo, desde un gestor).
        /// </summary>
        protected Interaccion() { }

        /// <summary>
        /// Agrega una nueva nota a la interacción.
        /// </summary>
        /// <param name="nota">Texto de la nota a agregar.</param>
        public void AgregarNota(string nota)
        {
            if (string.IsNullOrWhiteSpace(nota))
                return;

            if (string.IsNullOrEmpty(Notas))
                Notas = nota;
            else
                Notas += Environment.NewLine + nota;
        }
    }
}
