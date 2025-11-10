using System;

namespace Library
{
    public class Mensaje : Interaccion
    {
        public string Medio { get; private set; }

        public Mensaje(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string medio)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Medio = medio;
        }

        public Mensaje() : base() { }
    }
}