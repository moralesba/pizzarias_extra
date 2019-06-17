using Senai_Pizzaria_Extras.Domains;
using Senai_Pizzaria_Extras.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Senai_Pizzaria_Extras.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog = Senai_Pizzarias_Extra; user id=sa; pwd=132";

        public List<Usuarios> Listar()
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
        public Usuarios BuscarEmailSenha(string Email, string Senha)
        {
            
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "select id_usuario, email, senha, permissao from usuarios where email = @email and senha = @senha ";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@senha", Senha);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        Usuarios usuario = new Usuarios();

                        while (sdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(sdr["id_usuario"]);
                            usuario.Email = sdr["email"].ToString();
                            usuario.Permissao = sdr["Permissao"].ToString();
                        }
                        return usuario;
                    }
                }
                return null;
            }
        }
    }
}
