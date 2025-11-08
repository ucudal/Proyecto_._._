using System;

namespace Library
{
    // La interfaz IUsuario define las propiedades básicas
    // que deben tener todos los tipos de usuario del sistema.
    // Sirve como contrato para asegurar que cualquier clase que la implemente
    // tenga un estado de "Activo" y una "FechaCreacion".
    public interface IUsuario
    {
        // Indica si el usuario está activo o no 
        bool Activo { get; set; }

        // Fecha en la que el usuario fue creado o dado de alta.
        DateTime FechaCreacion { get; set; }
    }
}
