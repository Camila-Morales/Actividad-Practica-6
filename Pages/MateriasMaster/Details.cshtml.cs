using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EstudiantesRazor.DAL;
using EstudiantesRazor.Models;

namespace EstudiantesRazor.Pages.MateriasMaster
{
    public class DetailsModel : PageModel
    {
        private readonly EstudiantesRazor.DAL.AppDbContext _context;

        public DetailsModel(EstudiantesRazor.DAL.AppDbContext context)
        {
            _context = context;
        }

        public Materia Materia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FirstOrDefaultAsync(m => m.IdMateria == id);
            if (materia == null)
            {
                return NotFound();
            }
            else
            {
                Materia = materia;
            }
            return Page();
        }
    }
}
