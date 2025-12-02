using System;

namespace Library
{
    /// <summary>
    /// Define las propiedades básicas que deben tener todos los tipos de usuario del sistema.
    /// Sirve como contrato para asegurar que cualquier clase que la implemente
    /// mantenga información sobre su estado de actividad y su fecha de creación.
    /// </summary>
    public interface IUsuario
    {
        /// <summary>
        /// Identificador único del usuario dentro del sistema.
        /// </summary>
        int Id { get; set; }
        
        /// <summary>
        /// Indica si el usuario está activo o no.
        /// </summary>
        bool Activo { get; set; }

        /// <summary>
        /// Fecha en la que el usuario fue creado o registrado en el sistema.
        /// </summary>
        DateTime FechaCreacion { get; set; }
    }
}