using System;


/// <summary>
/// Excepción que se lanza cuando se intenta operar con un cliente
/// que no tiene un vendedor asignado.
/// </summary>
public class ClienteSinVendedorAsignadoException : Exception
{
    /// <summary>
    /// Constructor que recibe el mensaje de error a mostrar.
    /// </summary>
    /// <param name="mensaje">Mensaje que describe la excepción.</param>
    public ClienteSinVendedorAsignadoException(string mensaje) : base(mensaje)
    {
    }
}