using System;

public class ClienteSinVendedorAsignadoException : Exception
{
    public ClienteSinVendedorAsignadoException(string mensaje) : base(mensaje)
    {
    }
}