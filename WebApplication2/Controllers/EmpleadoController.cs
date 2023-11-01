using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmmpleadoController : ControllerBase
    {

        private readonly ILogger<EmmpleadoController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public EmmpleadoController(
            ILogger<EmmpleadoController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("Empleado")]
        public async Task<IActionResult> PostEmpleado([FromBody] Empleado Empleado)
        {
            _aplicacionContexto.Empleado.Add(Empleado);
            _aplicacionContexto.SaveChanges();
            return Ok(Empleado);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEmpleado()
        {
            List<Empleado> listEmpleado = _aplicacionContexto.Empleado.ToList();

            return StatusCode(StatusCodes.Status200OK, listEmpleado);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> EditEmpleado([FromBody] Empleado Empleado)
        {
            _aplicacionContexto.Empleado.Update(Empleado);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> DeleteEmpleado(int? id)
        {
            Empleado Empleado = _aplicacionContexto.Empleado.Find(id);
            _aplicacionContexto.Empleado.Remove(Empleado);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}