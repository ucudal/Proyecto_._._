using System;

namespace Library
{
    /// <summary>
    /// Representa a un usuario común del sistema.
    /// Implementa la interfaz IUsuario.
    /// </summary>
    public class Usuario : IUsuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indica si el usuario está activo o no.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha en la que el usuario fue creado.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor que inicializa un nuevo usuario con estado y fecha de creación.
        /// </summary>
        /// <param name="activo">Estado inicial del usuario (activo/inactivo).</param>
        /// <param name="fechaCreacion">Fecha de creación del usuario.</param>
        public Usuario(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
            Id = 0; // Se asignará luego en el gestor
        }
    }
}