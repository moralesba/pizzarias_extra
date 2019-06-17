using System;
using System.Collections.Generic;

namespace Senai_Pizzaria_Extras.Domains
{
    public partial class Pizzarias
    {
        public int IdPizzarias { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string OpcaoVegana { get; set; }
        public string CategoriaPreco { get; set; }
    }
}
