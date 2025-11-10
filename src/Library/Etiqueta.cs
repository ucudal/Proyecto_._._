namespace Library
{
    public class Etiqueta
    {
        // Atributo privado donde guardo el nombre de la etiqueta
        private string nombre;

        // Constructor que recibe el nombre al crear la etiqueta
        public Etiqueta(string nombre)
        {
            // Asigno el valor del parámetro al atributo de la clase
            this.nombre = nombre;
        }

        // Método que devuelve el nombre de la etiqueta
        public string ObtenerNombre()
        {
            return nombre;
        }
    }
}