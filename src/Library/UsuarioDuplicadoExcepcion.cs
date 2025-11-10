using System;

public class UsuarioDuplicadoException : Exception
{
    public UsuarioDuplicadoException(string mensaje) : base(mensaje)
    {
    }
}