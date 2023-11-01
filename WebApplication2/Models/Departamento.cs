using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Departamento
    {
        [Key]
        public int iddepartamento { get; set; }
        public string nombre { get; set; }
        public string area { get; set; }
        
    }
}