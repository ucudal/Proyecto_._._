using System;
using System.Collections.Generic;

namespace Library
{
    // Esta clase gestiona todas las interacciones del sistema (llamadas, mensajes, reuniones, correos)
    // Permite agregar, obtener, mostrar y eliminar interacciones.
    public class GestorInteracciones
    {
        // Lista que actúa como nuestra "base de datos"
        public List<Interaccion> interacciones = new List<Interaccion>();

        // Contador interno para asignar IDs automáticos
        private int proximoId = 1;

        // Singleton, mantiene una única instancia del gestor
        private static GestorInteracciones instancia;

        public static GestorInteracciones Instancia
        {
            get
            {
                // Si la instancia es nula, se crea
                return instancia ?? (instancia = new GestorInteracciones());
            }
        }

        // Constructor privado: evita crear objetos con "new"
        private GestorInteracciones() { }

        // Método para agregar una nueva interacción según su tipo
        public int AgregarInteraccion(string tipo, DateTime fecha, string descripcion, string notas, bool respondida, string direccion)
        {
            Interaccion nueva = null;

            // Se crea el tipo de interacción según el texto recibido
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

            // Asignamos los datos comunes
            nueva.Id = proximoId;
            nueva.Fecha = fecha;
            nueva.Descripcion = descripcion;
            nueva.Notas = notas;
            nueva.Respondida = respondida;
            nueva.Direccion = direccion;

            // Agregamos a la lista general
            interacciones.Add(nueva);

            // Incrementamos el contador
            proximoId++;

            // Devolvemos el ID asignado
            return nueva.Id;
        }

        // Método para obtener una interacción por su ID
        public Interaccion ObtenerInteraccion(int id)
        {
            for (int i = 0; i < interacciones.Count; i++)
            {
                if (interacciones[i].Id == id)
                {
                    return interacciones[i];
                }
            }
            return null;
        }

        // Método para mostrar todas las interacciones
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

        // Método para eliminar una interacción por su ID
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
