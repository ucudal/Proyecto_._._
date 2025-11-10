using System;
namespace Library
{
    public class Correo : Interaccion
    {
        public Correo(DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
        }
    }
}