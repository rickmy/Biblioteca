using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Negocio.Entidades
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public string Codigo { get; set; }
        public int LectorId { get; set; }
        public Lector Lector { get; set; }
        public DateTime Fecha { get; set; }
        public int BibliotecId { get; set; }
        public Bibliotec Bibliotec { get; set; }
        public int BibliotecarioId { get; set; }
        public Bibliotecario Bibliotecario { get; set; }
        public List<PrestamoLibros> PrestamoLibros { get; set; } = new List<PrestamoLibros>();
        public static int PrestamosHechos { get; set; }

        public string Prestar(Prestamo prestamo, Libro libro)
        {

            prestamo.PrestamoLibros.Add(new PrestamoLibros
            {
                Libro = libro,
                Prestamo = prestamo
            });

            PrestamosHechos++;

            return $"El pretamo con codigo {prestamo.Codigo} tiene el libro {libro.Titulo}";

        }
    }
}
