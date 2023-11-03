using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TituloController : ControllerBase
    {

        private readonly ILogger<TituloController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public TituloController(
            ILogger<TituloController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("Titulo")]
        public async Task<IActionResult> PostTitulo([FromBody] Titulo Titulo)
        {
            _aplicacionContexto.Titulo.Add(Titulo);
            _aplicacionContexto.SaveChanges();
            return Ok(Titulo);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetTitulo()
        {
            List<Titulo> listTitulo = _aplicacionContexto.Titulo.ToList();

            return StatusCode(StatusCodes.Status200OK, listTitulo);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> EditTitulo([FromBody] Titulo Titulo)
        {
            _aplicacionContexto.Titulo.Update(Titulo);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> DeleteTitulo(int? id)
        {
            Titulo Titulo = _aplicacionContexto.Titulo.Find(id);
            _aplicacionContexto.Titulo.Remove(Titulo);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}