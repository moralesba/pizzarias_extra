using Senai_Pizzaria_Extras.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Pizzaria_Extras.Interfaces
{
    interface IPizzariaRepositorio
    {
        List<Pizzarias> Listar();
        void Cadastrar(Pizzarias pizzarias);
    }
}
