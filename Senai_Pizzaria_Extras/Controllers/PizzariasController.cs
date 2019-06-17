using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_Pizzaria_Extras.Domains;
using Senai_Pizzaria_Extras.Interfaces;
using Senai_Pizzaria_Extras.Repositorios;

namespace Senai_Pizzaria_Extras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzariasController : ControllerBase
    {
        private IPizzariaRepositorio PizzariaRepositorio { get; set; }

        public PizzariasController()
        {
            PizzariaRepositorio = new PizzariaRepositorio();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(PizzariaRepositorio.Listar());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(Pizzarias pizzarias)
        {
            try
            {
                PizzariaRepositorio.Cadastrar(pizzarias);

                return Ok(new
                {
                    mensagem = "Pizzaria Cadastrada"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}