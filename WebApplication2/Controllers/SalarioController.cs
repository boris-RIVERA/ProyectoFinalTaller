using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;


namespace SalarioVideoJuego.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SalarioController : ControllerBase
    {

        private readonly ILogger<SalarioController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public SalarioController(
            ILogger<SalarioController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("Salario")]
        public async Task<IActionResult> PostSalario([FromBody] Salarios Salario)
        {
            _aplicacionContexto.Salario.Add(Salario);
            _aplicacionContexto.SaveChanges();
            return Ok(Salario);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSalario()
        {
            List<Salarios> listSalario = _aplicacionContexto.Salario.ToList();

            return StatusCode(StatusCodes.Status200OK, listSalario);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> EditSalario([FromBody] Salarios Salario)
        {
            _aplicacionContexto.Salario.Update(Salario);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> DeleteSalario(int? id)
        {
            Salarios Salario = _aplicacionContexto.Salario.Find(id);
            _aplicacionContexto.Salario.Remove(Salario);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}