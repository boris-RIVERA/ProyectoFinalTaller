using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Empleado
    {
        [Key]
        public int idempleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string genero { get; set; }
        public DateTime fechanacimiento { get; set; }

        [ForeignKey("VideoJuego")]
        public int iddepartamento { get; set; }



    }
}