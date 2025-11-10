using System;
namespace Library
{
    public class Reunion : Interaccion
    {
        // Atributo donde guardo el lugar donde se realiza la reunión
        private string lugar;

        // Constructor que recibe todos los datos de la interacción y además el lugar
        // Usa base para llamar al constructor de la clase Interaccion
        public Reunion(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string lugar)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            // Asigno el valor del parámetro lugar al atributo de esta clase
            this.lugar = lugar;
        }

        // Método que devuelve true si la reunión es en una fecha futura
        public bool esProxima()
        {
            return Fecha > DateTime.Now;
        }
    }
}