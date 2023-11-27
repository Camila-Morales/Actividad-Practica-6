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
    public class IndexModel : PageModel
    {
        private readonly EstudiantesRazor.DAL.AppDbContext _context;

        public IndexModel(EstudiantesRazor.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Estudiantes> Estudiantes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Estudiantes = await _context.Estudiantes.ToListAsync();
        }
    }
}
