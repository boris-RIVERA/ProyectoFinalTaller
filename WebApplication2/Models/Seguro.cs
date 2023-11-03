using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Seguro
    {
        [Key]
        public int idseguro { get; set; }
        public string tipo { get; set; }
        public string importe { get; set; }
        public DateTime fechaimporte { get; set; }


    }
}