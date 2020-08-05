using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Interface
{
    public interface IPersona
    {
        public int Id { get; set; }

        public string Saludo();

        public string Despedida();

    }
}
