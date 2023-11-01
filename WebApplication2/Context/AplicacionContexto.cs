using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Titulo> Titulo { get; set; }
        public DbSet<Empleado> Empleado { get; set; }


    }
}
