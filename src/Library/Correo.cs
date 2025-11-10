using System;

namespace Library
{
    public class Correo : Interaccion
    {
        // Constructor completo que delega en la clase base
        public Correo(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
        }

        // Constructor vacío para permitir creación sin parámetros (por ejemplo desde GestorInteracciones)
        public Correo() : base() { }
    }
}