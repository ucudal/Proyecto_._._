using System;
using System.Collections.Generic;

namespace Library
{
    public class GestorInteracciones
    {
        public List<Interaccion> interacciones = new List<Interaccion>();
        private int proximoId = 1;

        private static GestorInteracciones instancia;
        public static GestorInteracciones Instancia
        {
            get { return instancia ?? (instancia = new GestorInteracciones()); }
        }

        private GestorInteracciones() { }

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

        public Interaccion ObtenerInteraccion(int id)
        {
            for (int i = 0; i < interacciones.Count; i++)
            {
                if (interacciones[i].Id == id)
                    return interacciones[i];
            }
            return null;
        }

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
