using Biblioteca.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Negocio.Entidades
{
    public class Bibliotec : IPersona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public List<Devolucion> Devoluciones { get; set; } = new List<Devolucion>();
        public List<Usuario> Bibliotecarios { get; set; } = new List<Usuario>();
        public List<Usuario> Lectores { get; set; } = new List<Usuario>();

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
    }
}
