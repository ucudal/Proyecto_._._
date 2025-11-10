using System;

public class InteraccionSinDescripcionException : Exception
{
    public InteraccionSinDescripcionException(string mensaje) : base(mensaje)
    {
    }
}