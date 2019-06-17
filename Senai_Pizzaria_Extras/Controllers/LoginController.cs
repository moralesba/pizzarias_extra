using System;
using Microsoft.AspNetCore.Mvc;
using Senai_Pizzaria_Extras.Interfaces;
using Senai_Pizzaria_Extras.Domains;
using Senai_Pizzaria_Extras.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Senai_Pizzaria_Extras.Repositorios;

namespace Senai_Pizzaria_Extras.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepositorio UsuarioRepositorio { get; set; }
        public LoginController()
        {
            UsuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = UsuarioRepositorio.BuscarEmailSenha(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Permissao.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim("Permissao", usuarioBuscado.Permissao)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("token-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Pizzarias.WebApi",
                    audience: "Pizzarias.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception xx)
            {
                return BadRequest(xx.Message);
            }
        }
    }
}