using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstudiantesRazor.DAL;
using EstudiantesRazor.Models;

namespace EstudiantesRazor.Pages.EstudiantesMaster
{
    public class EditModel : PageModel
    {
        private readonly EstudiantesRazor.DAL.AppDbContext _context;

        public EditModel(EstudiantesRazor.DAL.AppDbContext context)
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

            var estudiantes =  await _context.Estudiantes.FirstOrDefaultAsync(m => m.IdEstudiantes == id);
            if (estudiantes == null)
            {
                return NotFound();
            }
            Estudiantes = estudiantes;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Estudiantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudiantesExists(Estudiantes.IdEstudiantes))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstudiantesExists(int id)
        {
            return _context.Estudiantes.Any(e => e.IdEstudiantes == id);
        }
    }
}
