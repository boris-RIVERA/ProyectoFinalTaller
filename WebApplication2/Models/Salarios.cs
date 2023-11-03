using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Salarios
    {
        [Key]
        public int idsalario { get; set; }
        public string salario { get; set; }
        public DateTime fechainicio { get; set; }
        
    }
}