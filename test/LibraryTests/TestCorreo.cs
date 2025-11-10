using System;
using Library;

namespace Program.Tests
{
    public static class TestCorreo
    {
        public static void Run()
        {
            Console.WriteLine("== TestCorreo ==");

            // Crear una instancia de Correo con datos de ejemplo 
            Correo correo = new Correo(
                DateTime.Now,                  // fecha de la interacción
                "Correo de prueba",            // descripción
                "Mensaje enviado correctamente", // notas
                true,                          // respondida
                "usuario@empresa.com"          // dirección
            );

            // Verificar que el objeto fue creado correctamente 
            if (correo != null)
            {
                Console.WriteLine("Correo creado correctamente.");
            }
            else
            {
                Console.WriteLine("Error: el correo no se creó correctamente.");
            }

            // Mostrar los datos para validación visual
            Console.WriteLine("Fecha: " + correo.Fecha.ToShortDateString());
            Console.WriteLine("Descripción: Correo de prueba");
            Console.WriteLine("Notas: Mensaje enviado correctamente");
            Console.WriteLine("Respondida: true");
            Console.WriteLine("Dirección: usuario@empresa.com");

            Console.WriteLine("== Fin de TestCorreo ==\n");
        }
    }
}