
using Biblioteca.Negocio.Entidades;
using System;

namespace Biblioteca.Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            Libro libroUno = new Libro { Codigo = 2020, Titulo = "HP", Editorial = "Salambra", Autor = "JKR" };

            Bibliotecario biblio = new Bibliotecario { PrimerNombre = "Fercho", PrimerApellido = "Perez", Correo = "fp@.copm", Telefono = "0992563584" };

            Lector lector = new Lector { PrimerNombre = "Ricardo", PrimerApellido = "Yaguachi", Correo = "r@r.com", Telefono = "0992563584", TipoLector = "Fanatico", Preferencias = "Aventura" };

            string prestamo = biblio.Prestamo(lector, libroUno);

            Console.WriteLine($"{prestamo} atendido por : {biblio.PrimerNombre} {biblio.PrimerApellido}");
        }
    }
}
