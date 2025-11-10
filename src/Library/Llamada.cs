using System;

namespace Library
{
    public class Llamada : Interaccion
    {
        public string Duracion { get; private set; }

        public Llamada(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string duracion)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Duracion = duracion;
        }

        public Llamada() : base() { }
    }
}