using Biblioteca.Interface;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Entidades
{
    public class Bibliotec : IPersona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public List<Devolucion> Devoluciones { get; set; } = new List<Devolucion>();
        public List<Bibliotecario> Bibliotecarios { get; set; } = new List<Bibliotecario>();

        public string Despedida()
        {
            return $"Gracias por preferirnos";
        }

        public string Saludo()
        {
            return $"Bienvenido a la Biblioteca {Nombre}";
        }

        public string MostrarSaludo(IPersona persona)
        {
            return persona.Saludo();
        }

        public void AñadirBibliotecario(Bibliotecario bibliotecario)
        {
            this.Bibliotecarios.Add(bibliotecario);
        }

        

    }
}
