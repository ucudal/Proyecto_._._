using System;
using System.Reflection;
using Moq;
using NUnit.Framework;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Tests
{
    // Fixture de tests para Facade (NUnit)
    // Comentarios añadidos para clarificar intención y puntos a tener en cuenta.
    [TestFixture]
    public class FacadeTests
    {
        // Test simple: la propiedad singleton debe devolver siempre la misma instancia
        [Test]
        public void Instance_ReturnsSameSingletonInstance()
        {
            // Arrange & Act
            var f1 = Facade.Instance;
            var f2 = Facade.Instance;

            // Assert: referencias idénticas (mismo objeto)
            Assert.That(f1, Is.SameAs(f2));
        }

        // Test del flujo "usuario no encontrado" en GetUserInfo
        // Aquí usamos Moq para simular el repositorio de usuarios y forzar la respuesta null.
        [Test]
        public void GetUserInfo_WhenUserNotFound_ReturnsNotFoundMessage()
        {
            Mock<IUsersRepository> mockedRepository;
            var facade = CreateFacadeWithMockRepo(out mockedRepository);

            // Configuramos el mock: cuando se busque "Test" devolvemos null
            mockedRepository.Setup(r => r.Find("Test")).Returns((User)null);

            // Act
            var actual = facade.GetUserInfo("Test");

            // Assert: esperamos el mensaje específico. Atención: el test es frágil a cambios en el texto.
            Assert.That(actual, Is.EqualTo("El usuario de Discord 'Test' no es usuario de esta aplicación."));

            // Verificamos que el mock recibió la llamada esperada exactamente una vez
            mockedRepository.Verify(r => r.Find("Test"), Times.Once);
        }

        // Test cuando el usuario existe pero no tiene roles asignados
        [Test]
        public void GetUserInfo_WhenUserExistsWithoutRoles_FormatsEmptyRoles()
        {
            Mock<IUsersRepository> mockedRepository;
            var facade = CreateFacadeWithMockRepo(out mockedRepository);

            // Creamos un usuario real (dominio) sin roles
            var user = new User("Test"); // sin roles
            mockedRepository.Setup(r => r.Find("Test")).Returns(user);

            // Act
            var actual = facade.GetUserInfo("Test");

            // Assert: comprobamos el formato esperado (roles vacíos -> '')
            Assert.That(actual, Is.EqualTo("El usuario 'Test' tiene los roles '' en esta aplicación."));
            mockedRepository.Verify(r => r.Find("Test"), Times.Once);
        }

        // Test cuando el usuario tiene roles: el string debe listar los nombres separados por coma
        [Test]
        public void GetUserInfo_WhenUserExistsWithRoles_ListsCommaSeparatedRoleNames()
        {
            Mock<IUsersRepository> mockedRepository;
            var facade = CreateFacadeWithMockRepo(out mockedRepository);

            var user = new User("Test");
            // Añadimos roles estándar (Role.Admin y Role.User son singletons definidos en Domain)
            user.AddRole(Role.Admin);
            user.AddRole(Role.User);
            mockedRepository.Setup(r => r.Find("Test")).Returns(user);

            var actual = facade.GetUserInfo("Test");

            // Nota: el test exige el orden y el formato exacto "Admin, User"
            Assert.That(actual, Is.EqualTo("El usuario 'Test' tiene los roles 'Admin, User' en esta aplicación."));
            mockedRepository.Verify(r => r.Find("Test"), Times.Once);
        }

        // Test adicional que simplemente verifica que se usa Role.ToString/Name en la concatenación
        [Test]
        public void GetUserInfo_UsesRoleToStringInJoin()
        {
            Mock<IUsersRepository> mockedRepository;
            var facade = CreateFacadeWithMockRepo(out mockedRepository);

            var user = new User("Test");
            user.AddRole(Role.User);
            mockedRepository.Setup(r => r.Find("Test")).Returns(user);

            var actual = facade.GetUserInfo("Test");

            // Aquí usamos Contains para no depender del texto completo; solo comprobamos que aparece el nombre del rol.
            Assert.That(actual, Does.Contain(Role.User.Name));
            mockedRepository.Verify(r => r.Find("Test"), Times.Once);
        }

        // crea una instancia de Facade y le inyecta (por reflection) un mock de IUsersRepository.
        // Comentario: usamos reflection porque Facade maneja internamente su repo (singleton) y no expone setter.
        // Esto es un patrón aceptable para tests, pero si podés cambiar Facade para inyectar dependencias sería mejor.
        private static Facade CreateFacadeWithMockRepo(out Mock<IUsersRepository> mockedRepository)
        {
            // Mock estrictamente configurado: si se llama a un método no configurado, el test fallará.
           
            mockedRepository = new Mock<IUsersRepository>(MockBehavior.Strict);

            var facadeType = typeof(Facade);
            
            // Intentamos obtener la propiedad pública/estática "Instance"
            var instanceProp = facadeType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            var facadeInstance = instanceProp.GetValue(null);

            // Si por alguna razón todavía es null (poco común), forzamos su creación
            if (facadeInstance == null)
            {
                facadeInstance = Facade.Instance;
            }

            // Buscamos el campo privado (de instancia) que almacena el repositorio de usuarios.
           
            var repoField = facadeType.GetField("usersRepository", BindingFlags.NonPublic | BindingFlags.Instance);

            // Comprobación en tiempo de test: si no encontramos el campo, el test falla con mensaje claro.
            Assert.That(repoField, Is.Not.Null, "No se encontró el campo privado usersRepository en Facade.");

            // Inyectamos el mock en la instancia existente de Facade
            repoField.SetValue(facadeInstance, mockedRepository.Object);

            // Devolvemos la instancia 
            return (Facade)facadeInstance;
        }
    }
}