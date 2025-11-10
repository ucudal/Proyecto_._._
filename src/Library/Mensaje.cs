using System;

namespace Library
{
    // La clase Mensaje hereda de la clase Interaccion
    public class Mensaje : Interaccion
    {
        // Campo privado que guarda el medio por el cual se envía el mensaje
        private string medio;

        // Constructor de la clase Mensaje
        // Recibe los datos de una interacción y el medio específico del mensaje
        public Mensaje(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string medio)
            : base(fecha, descripcion, notas, respondida, direccion) // Llama al constructor de la clase base
        {
            this.medio = medio; 
        }
    }
}