using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;


namespace SeguroVideoJuego.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SeguroController : ControllerBase
    {

        private readonly ILogger<SeguroController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public SeguroController(
            ILogger<SeguroController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("Seguro")]
        public async Task<IActionResult> PostSeguro([FromBody] Seguro Seguro)
        {
            _aplicacionContexto.Seguro.Add(Seguro);
            _aplicacionContexto.SaveChanges();
            return Ok(Seguro);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSeguro()
        {
            List<Seguro> listSeguro = _aplicacionContexto.Seguro.ToList();

            return StatusCode(StatusCodes.Status200OK, listSeguro);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> EditSeguro([FromBody] Seguro Seguro)
        {
            _aplicacionContexto.Seguro.Update(Seguro);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> DeleteSeguro(int? id)
        {
            Seguro Seguro = _aplicacionContexto.Seguro.Find(id);
            _aplicacionContexto.Seguro.Remove(Seguro);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}