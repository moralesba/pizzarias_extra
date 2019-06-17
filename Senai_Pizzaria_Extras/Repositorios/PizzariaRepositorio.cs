using Senai_Pizzaria_Extras.Domains;
using Senai_Pizzaria_Extras.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Pizzaria_Extras.Repositorios
{
    public class PizzariaRepositorio : IPizzariaRepositorio
    {
        public List<Pizzarias> Listar()
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                return ctx.Pizzarias.ToList();
            }
        }
        public void Cadastrar(Pizzarias pizzarias)
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                ctx.Pizzarias.Add(pizzarias);
                ctx.SaveChanges();
            }
        }
    }
}
