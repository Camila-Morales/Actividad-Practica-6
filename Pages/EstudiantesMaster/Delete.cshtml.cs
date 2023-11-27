using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EstudiantesRazor.DAL;
using EstudiantesRazor.Models;

namespace EstudiantesRazor.Pages.EstudiantesMaster
{
    public class DeleteModel : PageModel
    {
        private readonly EstudiantesRazor.DAL.AppDbContext _context;

        public DeleteModel(EstudiantesRazor.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiantes Estudiantes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes.FirstOrDefaultAsync(m => m.IdEstudiantes == id);

            if (estudiantes == null)
            {
                return NotFound();
            }
            else
            {
                Estudiantes = estudiantes;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes != null)
            {
                Estudiantes = estudiantes;
                _context.Estudiantes.Remove(Estudiantes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
