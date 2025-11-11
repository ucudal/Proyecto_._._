using System;

/// <summary>
/// Excepción personalizada que se lanza cuando se intenta crear un usuario que ya existe.
/// </summary>
public class UsuarioDuplicadoException : Exception
{
    /// <summary>
    /// Constructor de la excepción que recibe un mensaje descriptivo.
    /// </summary>
    /// <param name="mensaje">Mensaje que describe el motivo de la excepción.</param>
    public UsuarioDuplicadoException(string mensaje) : base(mensaje)
    {
    }
}