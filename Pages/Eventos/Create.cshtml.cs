using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Eventos
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public CreateModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Evento Evento { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var ubicacion = await _context.Ubicaciones
                .Include(u => u.Eventos)
                .FirstOrDefaultAsync(u => u.IdUbicacion == Evento.IdUbicacion);

            if (ubicacion == null)
            {
                // Manejar el caso en el que no se encuentra la ubicación
                return NotFound();
            }

            ubicacion.Eventos.Add(Evento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}