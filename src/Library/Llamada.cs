using System;
namespace Library
{
    public class Llamada : Interaccion
    {
        // Atributo donde guardo la duración de la llamada
        private string duracion;

        // Constructor que recibe todos los datos de la interacción y además la duración
        // Llama al constructor de la clase base (Interaccion)
        public Llamada(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string duracion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            // Asigno el valor del parámetro duracion al atributo de esta clase
            this.duracion = duracion;
        }
    }
}