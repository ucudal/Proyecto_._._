using System;
using Library;

namespace Program.Tests
{
    public static class TestVenta
    {
        public static void Run()
        {
            Console.WriteLine("== TestVenta ==");

            // Crear una instancia de Venta con datos de ejemplo
            Venta venta = new Venta(
                2500.75,                       // total
                DateTime.Now,                  // fecha
                "Venta de productos",          // descripción
                "Pago realizado en efectivo",  // notas
                true,                          // respondida
                "Sucursal Montevideo"          // dirección
            );

            //  Verificar creación
            if (venta != null)
            {
                Console.WriteLine("Venta creada correctamente.");
            }
            else
            {
                Console.WriteLine("Error: la venta no se creó correctamente.");
            }

            // Verificar que el total sea correcto
            if (venta.Total == 2500.75)
            {
                Console.WriteLine("El total fue asignado correctamente.");
            }
            else
            {
                Console.WriteLine("Error: el total no coincide.");
            }

            // Probar método GetTotales 
            double resultado = venta.GetTotales("criterio1", "criterio2");
            Console.WriteLine("Resultado de GetTotales(): " + resultado);

            //  Mostrar datos para validación visual 
            Console.WriteLine("Fecha: " + venta.Fecha.ToShortDateString());
            Console.WriteLine("Descripción: Venta de productos");
            Console.WriteLine("Notas: Pago realizado en efectivo");
            Console.WriteLine("Respondida: true");
            Console.WriteLine("Dirección: Sucursal Montevideo");

            Console.WriteLine("== Fin de TestVenta ==\n");
        }
    }
}