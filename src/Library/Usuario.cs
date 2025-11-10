using System;

namespace Library
{
    // Representa a un usuario común del sistema
    public class Usuario : IUsuario
    {
        // Identificador único del usuario
        public int Id { get; set; }

        // Indica si el usuario está activo o no 
        public bool Activo { get; set; }

        // Fecha en la que el usuario fue creado 
        public DateTime FechaCreacion { get; set; }

        // Constructor que recibe los valores iniciales
        public Usuario(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
            Id = 0; // Se asignará luego en el gestor
        }
    }
}