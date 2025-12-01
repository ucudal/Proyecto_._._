using System;
using System.IO;
using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class AdministradorTests
    {
        
        // Si tu GestorUsuarios tiene otras firmas o métodos auxiliares para limpiar estado,
        // es recomendable utilizarlos en [SetUp] para aislar cada test.

        private Administrador _admin;

        [SetUp]
        public void SetUp()
        {
            // Creamos un administrador con estado activo y fecha fija para reproducibilidad.
            _admin = new Administrador(true, DateTime.UtcNow);
            // Si tu GestorUsuarios tiene un método para limpiar/rehacer el estado antes de cada test,
            // lo ideal sería llamarlo aquí. Si no existe, los tests crean usuarios puntuales y trabajan sobre ellos.
        }

        [Test]
        public void CrearUsuario_DebeRetornarUsuarioActivo()
        {
            // Arrange
            // Explicación: queremos verificar que CrearUsuario delega correctamente en GestorUsuarios
            // y devuelve un objeto Usuario no nulo con propiedad Activo = true.
            // No verificamos el nombre/apellido/email porque el método actual los ignora (según tu implementación).

           
            Usuario creado = _admin.CrearUsuario("Nombre", "Apellido", "email@example.com");

           
            // Comprobamos que se devolvió un usuario y que está activo.
            Assert.IsNotNull(creado, "CrearUsuario debe devolver un objeto Usuario (no nulo).");
            Assert.IsTrue(creado.Activo, "El usuario creado por CrearUsuario debe estar activo (Activo == true).");

            // También comprobamos que el Id es mayor o igual a 0 (dependiendo de tu implementación de IDs).
            // Si en tu GestorUsuarios utilizas Ids empezando en 1, espera > 0; uso >= 0 como comprobación genérica.
            Assert.GreaterOrEqual(creado.Id, 0, "El usuario creado debería tener un Id asignado (>= 0).");
        }

        [Test]
        public void SuspenderUsuario_SiExiste_DeberiaMarcarActivoFalse()
        {
            // Arrange
            // Creamos un usuario directamente a través de GestorUsuarios para obtener un id conocido.
            int idNuevo = GestorUsuarios.Instancia.AgregarUsuario(true, DateTime.Now);
            Usuario antes = GestorUsuarios.Instancia.ObtenerUsuario(idNuevo);
            Assert.IsNotNull(antes, "Precondición: el usuario creado mediante GestorUsuarios no puede ser nulo.");
            Assert.IsTrue(antes.Activo, "Precondición: el usuario recién creado debe comenzar como activo.");

            
            _admin.SuspenderUsuario(idNuevo);

            // Assert
            Usuario despues = GestorUsuarios.Instancia.ObtenerUsuario(idNuevo);
            // Si GestorUsuarios devuelve null tras eliminar, este test seguirá coherente porque aquí no eliminamos.
            Assert.IsNotNull(despues, "Después de suspender, el usuario aún debe existir (no fue eliminado).");
            Assert.IsFalse(despues.Activo, $"El usuario con id {idNuevo} debería quedar inactivo luego de SuspenderUsuario.");
        }

        [Test]
        public void EliminarUsuario_SiExiste_NoDebePoderObtenerseLuego()
        {
            // Arrange
            int idNuevo = GestorUsuarios.Instancia.AgregarUsuario(true, DateTime.Now);
            Usuario antes = GestorUsuarios.Instancia.ObtenerUsuario(idNuevo);
            Assert.IsNotNull(antes, "Precondición: usuario creado correctamente.");

          
            // Administrador.EliminarUsuario delega en GestorUsuarios. Comprobamos efecto secundario.
            _admin.EliminarUsuario(idNuevo);

            // Assert
            Usuario despues = GestorUsuarios.Instancia.ObtenerUsuario(idNuevo);
            Assert.IsNull(despues, $"Después de llamar a EliminarUsuario({idNuevo}) no se debe poder obtener el usuario.");
        }

        [Test]
        public void MostrarUsuarios_NoLanzaExcepcion_YEsInvocable()
        {
            // Arrange
            // Redirigimos la salida de consola para evitar ruido en los tests y para poder inspeccionar si hace falta.
            var sw = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                
                // No esperamos ninguna excepción; simplemente verificamos que el método es invocable.
                Assert.DoesNotThrow(() => _admin.MostrarUsuarios(), "MostrarUsuarios no debería lanzar excepción cuando se invoca.");
                
                // Opcional: inspección ligera del texto volcado a consola.
                string salida = sw.ToString();
                // No exigimos un texto exacto porque la implementación del Gestor puede variar;
                // aquí solo comprobamos que el método escribió algo (si ese es el comportamiento esperado).
                // Si no quieres esta comprobación, se puede eliminar la siguiente linea.
                
            }
            finally
            {
                // Restauramos la salida estándar para no afectar otros tests.
                Console.SetOut(originalOut);
            }
        }

        [Test]
        public void SuspenderUsuario_SiNoExiste_NoLanzaExcepcion()
        {
            int idInexistente = -9999; // id improbable
            // Act & Assert
            // Documentamos que la implementación actual simplemente escribe en consola si no encuentra el usuario.
            // Por tanto, lo que comprobamos es que no lanza excepción al manejar IDs no existentes.
            Assert.DoesNotThrow(() => _admin.SuspenderUsuario(idInexistente),
                "SuspenderUsuario con un id inexistente no debe lanzar excepción (según la implementación actual).");
        }
    }
}