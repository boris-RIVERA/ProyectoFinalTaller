using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {

        private readonly ILogger<DepartamentoController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public DepartamentoController(
            ILogger<DepartamentoController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("Departamento")]
        public async Task<IActionResult> PostDepartamento([FromBody] Departamento Departamento)
        {
            _aplicacionContexto.Departamento.Add(Departamento);
            _aplicacionContexto.SaveChanges();
            return Ok(Departamento);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDepartamento()
        {
            List<Departamento> listDepartamento = _aplicacionContexto.Departamento.ToList();

            return StatusCode(StatusCodes.Status200OK, listDepartamento);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> EditDepartamento([FromBody] Departamento Departamento)
        {
            _aplicacionContexto.Departamento.Update(Departamento);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> DeleteDepartamento(int? id)
        {
            Departamento Departamento = _aplicacionContexto.Departamento.Find(id);
            _aplicacionContexto.Departamento.Remove(Departamento);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}