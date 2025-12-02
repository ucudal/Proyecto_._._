using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Gestor de todas las interacciones (llamadas, reuniones, mensajes, correos) del sistema.
    /// Implementa el patrón Singleton.
    /// </summary>
    public class GestorInteracciones
    {
        private static GestorInteracciones instancia;
        private int proximoId = 1;

        /// <summary>
        /// Lista que almacena todas las interacciones registradas.
        /// </summary>
        public List<Interaccion> interacciones { get; } = new List<Interaccion>();

        private GestorInteracciones() { }

        /// <summary>
        /// Obtiene la instancia única del gestor.
        /// </summary>
        public static GestorInteracciones Instancia
        {
            get
            {
                if (instancia == null) instancia = new GestorInteracciones();
                return instancia;
            }
        }

        /// <summary>
        /// Agrega una nueva interacción al sistema según el tipo especificado.
        /// </summary>
        /// <param name="tipo">Tipo de interacción: "llamada", "reunion", "mensaje", "correo".</param>
        /// <param name="fecha">Fecha de la interacción.</param>
        /// <param name="descripcion">Descripción de la interacción.</param>
        /// <param name="notas">Notas adicionales de la interacción.</param>
        /// <param name="respondida">Indica si la interacción fue respondida.</param>
        /// <param name="direccion">Dirección asociada a la interacción.</param>
        /// <returns>ID asignado a la nueva interacción.</returns>
        /// <exception cref="ArgumentException">Si el tipo de interacción no es válido.</exception>
        public int AgregarInteraccion(string tipo, DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
        {
            if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentNullException(nameof(tipo));

            Interaccion nueva;

            switch (tipo.Trim().ToLowerInvariant())
            {
                case "llamada":
                    nueva = new Llamada();
                    break;
                case "reunion":
                case "reunión":
                    nueva = new Reunion();
                    break;
                case "mensaje":
                    nueva = new Mensaje();
                    break;
                case "correo":
                case "e-mail":
                case "email":
                    nueva = new Correo();
                    break;
                default:
                    // En lugar de escribir en consola, lanzamos una excepción (la UI deberá capturarla).
                    throw new ArgumentException($"Tipo de interacción no válido: '{tipo}'", nameof(tipo));
            }

            nueva.Id = proximoId++;
            nueva.Fecha = fecha;
            nueva.Descripcion = descripcion;
            nueva.Notas = notas;
            nueva.Respondida = respondida;
            nueva.Direccion = direccion;

            interacciones.Add(nueva);
            return nueva.Id;
        }

        /// <summary>
        /// Obtiene una interacción por su id.
        /// </summary>
        public Interaccion ObtenerPorId(int id)
        {
            return interacciones.Find(i => i.Id == id);
        }

        /// <summary>
        /// Elimina una interacción por su id.
        /// </summary>
        /// <returns>True si se eliminó; false si no se encontró.</returns>
        public bool EliminarInteraccion(int id)
        {
            var idx = interacciones.FindIndex(i => i.Id == id);
            if (idx >= 0)
            {
                interacciones.RemoveAt(idx);
                return true;
            }
            return false;
        }

    }
}
