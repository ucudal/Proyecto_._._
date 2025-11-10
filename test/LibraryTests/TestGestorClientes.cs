using System;
using Library;

namespace Program.Tests
{
    // Clase de prueba para verificar el correcto funcionamiento de GestorClientes
    public static class TestGestorClientes
    {
        // Método principal que ejecuta todas las pruebas del gestor de clientes
        public static void Run()
        {
            Console.WriteLine("== TestGestorClientes ==");

            // Se obtiene la instancia única (Singleton) del gestor
            GestorClientes gestor = GestorClientes.Instancia;

            //  AgregarCliente 
            int idCliente = gestor.AgregarCliente("Ana", "García", "ana@mail.com", "099111222");

            // Se obtiene el cliente recién agregado
            Cliente cliente = gestor.ObtenerCliente(idCliente);

            // Se verifica que se haya agregado correctamente
            if (cliente != null && cliente.Nombre == "Ana" && cliente.Apellido == "García")
                Console.WriteLine("AgregarCliente funciona correctamente.");
            else
                Console.WriteLine("Error en AgregarCliente.");

            //  ObtenerCliente
            Cliente clienteObtenido = gestor.ObtenerCliente(idCliente);
            if (clienteObtenido != null && clienteObtenido.Id == idCliente)
                Console.WriteLine("ObtenerCliente devuelve el cliente correcto.");
            else
                Console.WriteLine("Error en ObtenerCliente.");

            // ActualizarEmail
            bool actualizado = gestor.ActualizarEmail(idCliente, "nuevo@mail.com");
            if (actualizado && cliente.Email == "nuevo@mail.com")
                Console.WriteLine("ActualizarEmail actualiza correctamente el correo.");
            else
                Console.WriteLine("Error en ActualizarEmail.");

            // MostrarTodosClientes 
            Console.WriteLine("Mostrando todos los clientes registrados:");
            gestor.MostrarTodosClientes();

            // EliminarCliente 
            bool eliminado = gestor.EliminarCliente(idCliente);
            Cliente clienteEliminado = gestor.ObtenerCliente(idCliente);
            if (eliminado && clienteEliminado == null)
                Console.WriteLine("EliminarCliente elimina correctamente al cliente.");
            else
                Console.WriteLine("Error en EliminarCliente.");

            // Línea vacía para mantener ordenada la salida en consola
            Console.WriteLine();
        }
    }
}
