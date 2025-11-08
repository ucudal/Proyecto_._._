using System;

namespace Library
{
    
    // Representa a un usuario común del sistema, con propiedades básicas
    // como su estado (Activo) y la fecha en la que fue creado.
    public class Usuario : IUsuario
    {
        // Indica si el usuario está activo o no 
        public bool Activo { get; set; }

        // Fecha en la que el usuario fue creado 
        public DateTime FechaCreacion { get; set; }

       
        // Recibe los valores iniciales para las propiedades Activo y FechaCreacion.
        public Usuario(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
        }
    }
}