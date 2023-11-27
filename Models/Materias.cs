using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstudiantesRazor.Models
{
    public class Materia
    {
        [Key]
        public int IdMateria { get; set; }

        [Required]
        [DisplayName("Nombre de la materia")]
        public string? Nombre { get; set; }

        [Required]
        [DisplayName("Descripcion de la materia")]
        public string? Descripcion { get; set; }
    }
}
