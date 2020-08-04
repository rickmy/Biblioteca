using Biblioteca.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Negocio.Entidades
{
    public class Bibliotecario : Usuario
    {
        public int Id { get; set; }

        public string Prestamo(Lector lector, Libro libro) 
        {
            lector.LectorLibros.Add(new LectorLibros{ 
            Libro = libro,
            Lector = lector
            });

            return $"El libro {libro.Titulo} fue prestado a {lector.PrimerNombre} {lector.PrimerApellido}";
        }

        public string Devolucion(Lector lector, Libro libro)
        {
            lector.LectorLibros.Remove(new LectorLibros
            {
                Libro = libro,
                Lector = lector
            });

            return $"El libro {libro.Titulo} fue devuelto por {lector.PrimerNombre} {lector.PrimerApellido}" ;
        }
    }
}
