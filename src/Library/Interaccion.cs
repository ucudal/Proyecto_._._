using System;

namespace Library
{
    // Clase abstracta que representa una interacción general (por ejemplo, un mensaje, llamada, etc.)
    public abstract class Interaccion
    {
        // Identificador único de la interacción
        public int Id { get; set; }

        // Propiedad pública que almacena la fecha de la interacción
        public DateTime Fecha { get; set; }

        // Descripción breve de la interacción
        public string Descripcion { get; set; }

        // Notas adicionales asociadas a la interacción
        public string Notas { get; set; }

        // Indica si la interacción fue respondida o no
        public bool Respondida { get; set; }

        // Dirección asociada a la interacción 
        public string Direccion { get; set; }

        // Constructor protegido (solo accesible desde clases que hereden)
        protected Interaccion(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
        {
            Fecha = fecha;
            Descripcion = descripcion;
            Notas = notas;
            Respondida = respondida;
            Direccion = direccion;
        }

        // Constructor vacío (para poder crear instancias sin parámetros desde el Gestor)
        protected Interaccion() { }

        // Método que permite agregar una nueva nota a la interacción
        public void AgregarNota(string nota)
        {
            // Si la nota está vacía, no hace nada
            if (string.IsNullOrEmpty(nota))
                return;

            // Si no había notas previas, asigna la nueva nota directamente
            if (string.IsNullOrEmpty(Notas))
                Notas = nota;
            else
                // Si ya existían notas, agrega la nueva en una nueva línea
                Notas += Environment.NewLine + nota;
        }
    }
}