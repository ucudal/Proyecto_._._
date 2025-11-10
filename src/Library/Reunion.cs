using System;

namespace Library
{
    public class Reunion : Interaccion
    {
        public string Lugar { get; private set; }

        public Reunion(DateTime fecha, string descripcion, string notas, bool respondida, string direccion, string lugar)
            : base(fecha, descripcion, notas, respondida, direccion)
        {
            Lugar = lugar;
        }

        public Reunion() : base() { }

        public bool EsProxima()
        {
            return Fecha > DateTime.Now;
        }
    }
}   