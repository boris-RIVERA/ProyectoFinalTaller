using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Titulo
    {
        [Key]
        public int idtitulo { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }

        [ForeignKey("VideoJuego")]
        public int idempleado { get; set; }
    }
}