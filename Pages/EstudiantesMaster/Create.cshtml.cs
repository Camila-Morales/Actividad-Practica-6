using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EstudiantesRazor.DAL;
using EstudiantesRazor.Models;

namespace EstudiantesRazor.Pages.EstudiantesMaster
{
    public class CreateModel : PageModel
    {
        private readonly EstudiantesRazor.DAL.AppDbContext _context;

        public CreateModel(EstudiantesRazor.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Estudiantes Estudiantes { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Estudiantes.Add(Estudiantes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
