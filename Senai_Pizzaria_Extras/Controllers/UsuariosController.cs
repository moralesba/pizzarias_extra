using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_Pizzaria_Extras.Interfaces;
using Senai_Pizzaria_Extras.Repositorios;
using System.Data;

namespace Senai_Pizzaria_Extras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepositorio UsuarioRepositorio { get; set; }

        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepositorio();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(UsuarioRepositorio.Listar());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}