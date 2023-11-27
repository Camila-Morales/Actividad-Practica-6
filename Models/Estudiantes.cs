using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstudiantesRazor.Models
{
    public class Estudiantes
    {
        [Key]
        public int IdEstudiantes { get; set; }

        [Required]
        [DisplayName("Nombre del estudiante")]
        public string? Nombre { get; set; }

        [Required]
        [DisplayName("Apellido del estudiante")]
        public string? Apellido { get; set; }

        [Required]
        [DisplayName("Feacha de nacimiento del estudiante")]
        public DateOnly? FechaNacimiento { get; set; }
    }
}
