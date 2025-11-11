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
        /// <summary>
        /// Lista que almacena todas las interacciones registradas.
        /// </summary>
        public List<Interaccion> interacciones = new List<Interaccion>();

        private int proximoId = 1;

        /// <summary>
        /// Instancia única del gestor (Singleton).
        /// </summary>
        private static GestorInteracciones instancia;

        /// <summary>
        /// Propiedad para acceder al Singleton del gestor de interacciones.
        /// </summary>
        public static GestorInteracciones Instancia
        {
            get { return instancia ?? (instancia = new GestorInteracciones()); }
        }

        /// <summary>
        /// Constructor privado para impedir instanciación externa.
        /// </summary>
        private GestorInteracciones() { }

        /// <summary>
        /// Agrega una nueva interacción al sistema según el tipo especificado.
        /// </summary>
        /// <param name="tipo">Tipo de interacción: "llamada", "reunion", "mensaje", "correo".</param>
        /// <param name="fecha">Fecha de la interacción.</param>
        /// <param name="descripcion">Descripción de la interacción.</param>
        /// <param name="notas">Notas adicionales de la interacción.</param>
        /// <param name="respondida">Indica si la interacción fue respondida.</param>
        /// <param name="direccion">Dirección asociada a la interacción.</param>
        /// <returns>ID asignado a la nueva interacción o -1 si el tipo es inválido.</returns>
        public int AgregarInteraccion(string tipo, DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
        {
            Interaccion nueva = null;

            switch (tipo.ToLower())
            {
                case "llamada":
                    nueva = new Llamada();
                    break;
                case "reunion":
                    nueva = new Reunion();
                    break;
                case "mensaje":
                    nueva = new Mensaje();
                    break;
                case "correo":
                    nueva = new Correo();
                    break;
                default:
                    Console.WriteLine("Tipo de interacción no válido.");
                    return -1;
            }

            nueva.Id = proximoId;
            nueva.Fecha = fecha;
            nueva.Descripcion = descripcion;
            nueva.Notas = notas;
            nueva.Respondida = respondida;
            nueva.Direccion = direccion;

            interacciones.Add(nueva);
            proximoId++;

            return nueva.Id;
        }

        /// <summary>
        /// Obtiene una interacción por su ID.
        /// </summary>
        /// <param name="id">ID de la interacción a buscar.</param>
        /// <returns>La interacción encontrada o null si no existe.</returns>
        public Interaccion ObtenerInteraccion(int id)
        {
            for (int i = 0; i < interacciones.Count; i++)
            {
                if (interacciones[i].Id == id)
                    return interacciones[i];
            }
            return null;
        }

        /// <summary>
        /// Muestra todas las interacciones registradas por consola.
        /// </summary>
        public void MostrarTodasInteracciones()
        {
            for (int i = 0; i < interacciones.Count; i++)
            {
                Interaccion inter = interacciones[i];
                Console.WriteLine("ID: " + inter.Id +
                                  ", Tipo: " + inter.GetType().Name +
                                  ", Fecha: " + inter.Fecha.ToShortDateString() +
                                  ", Descripción: " + inter.Descripcion +
                                  ", Respondida: " + (inter.Respondida ? "Sí" : "No") +
                                  ", Dirección: " + inter.Direccion);
            }
        }

        /// <summary>
        /// Elimina una interacción por su ID.
        /// </summary>
        /// <param name="id">ID de la interacción a eliminar.</param>
        /// <returns>True si se eliminó correctamente; false si no se encontró.</returns>
        public bool EliminarInteraccion(int id)
        {
            for (int i = 0; i < interacciones.Count; i++)
            {
                if (interacciones[i].Id == id)
                {
                    interacciones.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
