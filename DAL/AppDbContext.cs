using EstudiantesRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesRazor.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
    }
}


