using System;

namespace Library
{
    
    public class Usuario : IUsuario
    {
        // Indica si el usuario está activo o no 
        public bool Activo { get; set; }

        // Fecha en la que el usuario fue creado 
        public DateTime FechaCreacion { get; set; }

        //  ID único para identificar el usuario
        public int Id { get; set; }

        // Recibe los valores iniciales para las propiedades Activo y FechaCreacion.
        public Usuario(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
            Id = 0;  // Inicializa Id
        }
    }
}