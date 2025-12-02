using System;

namespace Library
{
    /// <summary>
    /// Clase base abstracta para todos los tipos de usuario del sistema.
    /// Proporciona propiedades comunes como ID, estado y fecha de creación.
    /// </summary>
    public abstract class UsuarioBase : IUsuario
    {
        /// <summary>
        /// Identificador único del usuario dentro del sistema.
        /// Este valor es asignado automáticamente por el <see cref="GestorUsuarios"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indica si el usuario se encuentra activo en el sistema.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha en la que el usuario fue creado o registrado en el sistema.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor protegido utilizado por todas las clases derivadas.
        /// </summary>
        /// <param name="activo">Estado inicial del usuario.</param>
        /// <param name="fechaCreacion">Fecha de creación o registro.</param>
        protected UsuarioBase(bool activo, DateTime fechaCreacion)
        {
            Activo = activo;
            FechaCreacion = fechaCreacion;
            Id = 0;
        }
    }
}