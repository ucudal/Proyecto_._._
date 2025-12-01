using System;
using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class CorreoTests
    {
        [Test]
        public void ConstructorCompleto_AsignaPropiedadesCorrectamente()
        {
            var fecha = DateTime.Now;
            string descripcion = "Correo de prueba";
            string notas = "Notas adicionales";
            bool respondida = true;
            string direccion = "cliente@ejemplo.com";

            var correo = new Correo(fecha, descripcion, notas, respondida, direccion);

            // Verificamos que todas las propiedades se asignaron correctamente
            Assert.AreEqual(fecha, correo.Fecha);
            Assert.AreEqual(descripcion, correo.Descripcion);
            Assert.AreEqual(notas, correo.Notas);
            Assert.AreEqual(respondida, correo.Respondida);
            Assert.AreEqual(direccion, correo.Direccion);
        }

        [Test]
        public void ConstructorVacio_CreaObjetoSinErrores()
        {
            // Creamos un correo usando el constructor vacío
            var correo = new Correo();

            // Verificamos que el objeto no sea nulo y tenga valores por defecto
            Assert.IsNotNull(correo);
            Assert.AreEqual(default(DateTime), correo.Fecha);
            Assert.IsNull(correo.Descripcion);
            Assert.IsNull(correo.Notas);
            Assert.IsFalse(correo.Respondida);
            Assert.IsNull(correo.Direccion);
        }

        [Test]
        public void Correo_HeredadoDeInteraccion_SePuedeUsarComoInteraccion()
        {
            // Verificamos que un Correo es considerado una Interaccion
            var correo = new Correo();
            Interaccion interaccion = correo;

            Assert.IsInstanceOf<Interaccion>(interaccion);
        }
    }
}