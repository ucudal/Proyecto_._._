using System;
using System.Collections.Generic;
using Library;
using ProyectoCRM;

namespace Program.Tests
{
    /// <summary>
    /// Clase de prueba para verificar el correcto funcionamiento de la clase <see cref="Fachada"/>.
    /// Contiene diferentes pruebas sobre las funcionalidades principales del sistema CRM.
    /// </summary>
    public static class TestFachada
    {
        /// <summary>
        /// Ejecuta todas las pruebas de la clase <see cref="Fachada"/>.
        /// Muestra en consola los resultados de cada test individual.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("== TestFachada ==");

            // Se crea una nueva instancia de la fachada
            Fachada fachada = new Fachada();

            // -------------------------
            // PRUEBA: Registrar usuarios
            // -------------------------
            Console.WriteLine("-- Prueba de registro de usuarios --");

            /// <summary>Prueba del método <see cref="Fachada.RegistrarVendedor"/>.</summary>
            int idVendedor = fachada.RegistrarVendedor(true, DateTime.Now);

            /// <summary>Prueba del método <see cref="Fachada.RegistrarAdministrador"/>.</summary>
            int idAdmin = fachada.RegistrarAdministrador(true, DateTime.Now);

            if (idVendedor > 0 && idAdmin > 0)
                Console.WriteLine("Usuarios (vendedor y administrador) registrados correctamente.");
            else
                Console.WriteLine("Error al registrar usuarios.");

            // -------------------------
            // PRUEBA: Obtener usuarios
            // -------------------------
            /// <summary>Prueba del método <see cref="Fachada.ObtenerUsuarios"/>.</summary>
            List<Usuario> usuarios = fachada.ObtenerUsuarios();
            if (usuarios != null)
                Console.WriteLine($"Se obtuvieron {usuarios.Count} usuarios del sistema.");
            else
                Console.WriteLine("Error al obtener usuarios.");

            // -------------------------
            // PRUEBA: Registrar cliente
            // -------------------------
            Console.WriteLine("-- Prueba de registro de cliente --");

            /// <summary>Prueba del método <see cref="Fachada.RegistrarCliente"/>.</summary>
            fachada.RegistrarCliente(
                nombre: "Juan",
                apellido: "Pérez",
                telefono: "099123456",
                correo: "juan@correo.com",
                descripcion: "Cliente nuevo interesado en servicios premium.",
                genero: "Masculino",
                nacimiento: new DateTime(1990, 5, 10)
            );

            /// <summary>Prueba del método <see cref="Fachada.ObtenerClientes"/>.</summary>
            List<Cliente> clientes = fachada.ObtenerClientes();
            if (clientes != null)
                Console.WriteLine($"Clientes obtenidos correctamente (total: {clientes.Count}).");
            else
                Console.WriteLine("Error al obtener clientes.");

            // -------------------------
            // PRUEBA: Registrar etiqueta
            // -------------------------
            Console.WriteLine("-- Prueba de etiquetas --");

            /// <summary>Prueba del método <see cref="Fachada.CrearEtiqueta"/>.</summary>
            fachada.CrearEtiqueta("Importante");
            fachada.CrearEtiqueta("Nuevo");

            /// <summary>Prueba del método <see cref="Fachada.ObtenerEtiquetas"/>.</summary>
            List<Etiqueta> etiquetas = fachada.ObtenerEtiquetas();

            if (etiquetas.Count == 2)
                Console.WriteLine("Etiquetas creadas y recuperadas correctamente.");
            else
                Console.WriteLine("Error en la gestión de etiquetas.");

            // -------------------------
            // PRUEBA: Registrar venta
            // -------------------------
            Console.WriteLine("-- Prueba de registro de venta --");

            /// <summary>Prueba del método <see cref="Fachada.RegistrarVenta"/>.</summary>
            Venta venta = new Venta(1500, DateTime.Now, "Venta de producto A", "Pago en efectivo", true, "Sucursal Montevideo");
            fachada.RegistrarVenta(venta);

            /// <summary>Prueba del método <see cref="Fachada.ObtenerVentasEntre"/>.</summary>
            List<Venta> ventas = fachada.ObtenerVentasEntre(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            if (ventas != null)
                Console.WriteLine("Método de obtención de ventas ejecutado correctamente.");
            else
                Console.WriteLine("Error al obtener ventas.");

            // -------------------------
            // PRUEBA: Registrar interacción
            // -------------------------
            Console.WriteLine("-- Prueba de interacciones --");

            /// <summary>Prueba del método <see cref="Fachada.RegistrarInteraccion"/>.</summary>
            Cliente clienteTest = new Cliente()
            {
                Nombre = "Laura",
                Apellido = "Rodríguez",
                Email = "laura@correo.com",
                Telefono = "094567890",
                FechaNacimiento = new DateTime(1985, 3, 12),
                Genero = "Femenino",
                FechaUltimaInteraccion = DateTime.Now
            };

            fachada.RegistrarInteraccion(clienteTest, "Primera interacción de prueba.");

            /// <summary>Prueba del método <see cref="Fachada.ObtenerInteraccionesDeCliente"/>.</summary>
            List<Interaccion> interacciones = fachada.ObtenerInteraccionesDeCliente(clienteTest);

            if (interacciones.Count > 0)
                Console.WriteLine("Interacción registrada correctamente para el cliente.");
            else
                Console.WriteLine("Error al registrar interacción.");

            // -------------------------
            // FIN DE TEST
            // -------------------------
            Console.WriteLine();
            Console.WriteLine("== TestFachada finalizado correctamente ==\n");
        }
    }
}
