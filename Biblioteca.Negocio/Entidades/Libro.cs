using System.Collections.Generic;

namespace Biblioteca.Negocio.Entidades
{
    public class Libro 
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; } 
        public List<PrestamoLibros> LectorLibros { get; set; } = new List<PrestamoLibros>();

        public string Descripcion()
        {
            return $"El libro {this.Titulo} tiene como autor a: {this.Autor} y su codigo es {this.Codigo}.";
        }

        public string MiTituloes()
        {
            return $"Tengo como Título: {this.Titulo}.";
        }

        public string MiAutorEs()
        {
            return $"Mi Autor es: {this.Autor}.";
        }

        public string MiCodigoEs()
        {
            return $"Mi codigo es: {this.Codigo}.";
        }


    }
}
