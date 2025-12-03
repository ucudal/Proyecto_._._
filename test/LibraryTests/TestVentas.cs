using System;
using Library;
using NUnit.Framework;

public class Vendedores
{
    public void Add(Vendedor v1)
    {
        throw new NotImplementedException();
    }
}

public class Ventas
{
    public static void Add(Venta p0)
    {
        throw new NotImplementedException();
    }
}

public class Sistema
{
    public Sistema(Vendedores vendedores, object venta)
    {
        throw new NotImplementedException();
    }

    public object ObtenerVentasPorVendedor()
    {
        throw new NotImplementedException();
    }

    public (object vendedor, object cantidad, object bono) ObtenerTopVendedorConBono()
    {
        throw new NotImplementedException();
    }
}

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba unitaria para verificar el correcto funcionamiento de la clase <see cref="Venta"/>.
    /// </summary>
    public static class TestVenta
    {
        /// <summary>
        /// Ejecuta una serie de pruebas sobre la clase <see cref="Venta"/> para validar su comportamiento.
        /// </summary>
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


public void TopVendedorConBono()
{
    // 
    var Vendedores = new Vendedores();
    var repoVentas = new Venta();
    var sistema = new Sistema(Vendedores, Venta);

    var v1 = new Vendedor("1", "Juan");
    var v2 = new Vendedor("2", "Pedro");

    Vendedores.Add(v1);
    Vendedores.Add(v2);

    Venta.Add(new Venta("A", "1"));
    Venta.Add(new Venta("B", "1"));
    Venta.Add(new Venta("C", "2"));

    // 
    var (vendedor, cantidad, bono) = sistema.ObtenerTopVendedorConBono();

    // 
    Assert.Equals("1", vendedor.Id); // Juan tiene 2 ventas entonces es el top
    Assert.Equals(2, cantidad);
    Assert.Equals(200, bono);        // $100 por venta
}

public void ObtenerVentasPorVendedor()
{
    // 
    var Vendedores = new Vendedores();
    var repoVentas = new Venta();
    var sistema = new Sistema(Vendedores, Venta);

    var v1 = new Vendedor("1", "Juan");
    var v2 = new Vendedor("2", "Pedro");

    Vendedores.Add(v1);
    Vendedores.Add(v2);

    Ventas.Add(new Venta("A", "1"));
    Ventas.Add(new Venta("B", "1"));
    Ventas.Add(new Venta("C", "2"));

    // 
    var resultado = sistema.ObtenerVentasPorVendedor();

    //
    Assert.That(2, resultado["1"]); // Juan tiene 2 ventas
    Assert.That(1, resultado["2"]); // Pedro tiene 1 venta
}





