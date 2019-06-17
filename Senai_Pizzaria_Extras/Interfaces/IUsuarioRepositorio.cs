using Senai_Pizzaria_Extras.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Pizzaria_Extras.Interfaces
{
    interface IUsuarioRepositorio
    {
        Usuarios BuscarEmailSenha(string Email, string Senha);
        List<Usuarios> Listar();
    }
}
