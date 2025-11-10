using System;

namespace Library
{
    // Representa a un usuario común del sistema, con propiedades básicas
    // como su estado (Activo), la fecha de creación y un identificador único (Id)
    
    public class Usuario : IUsuario
    {
        // Identificador único del usuario
        public int Id { get; set; }

        // Indica si el usuario está activo o no 
        public bool Activo { get; set; }

        // Fecha en la que el usuario fue creado 
        public DateTime FechaCreacion { get; set; }

        // Constructor que recibe los valores iniciales
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