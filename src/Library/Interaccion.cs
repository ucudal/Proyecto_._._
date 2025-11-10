using System;

namespace Library
{
    // Clase abstracta que representa una interacción general (por ejemplo, un mensaje, llamada, etc.)
    public abstract class Interaccion
    {
        // Propiedad pública que almacena la fecha de la interacción
        public DateTime Fecha { get; set; }

        // Descripción breve de la interacción
        private string descripcion;

        // Notas adicionales asociadas a la interacción
        private string notas;

        // Indica si la interacción fue respondida o no
        private bool respondida;

        // Dirección asociada a la interacción 
        private string direccion;

        // Constructor protegido (solo accesible desde clases que hereden)
        protected Interaccion(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
        {
            Fecha = fecha;
            this.descripcion = descripcion;
            this.notas = notas;
            this.respondida = respondida;
            this.direccion = direccion;
        }

        // Propiedad pública para acceder y modificar si la interacción fue respondida
        public bool Respondida
        {
            get { return respondida; }
            set { respondida = value; }
        }

        // Método que permite agregar una nueva nota a la interacción
        public void agregarNota(string nota)
        {
            // Si la nota está vacía, no hace nada
            if (string.IsNullOrEmpty(nota))
                return;

            // Si no había notas previas, asigna la nueva nota directamente
            if (string.IsNullOrEmpty(notas))
                notas = nota;
            else
                // Si ya existían notas, agrega la nueva en una nueva línea
                notas += Environment.NewLine + nota;
        }
    }
}