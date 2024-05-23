using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventPlanner.Pages.Eventos
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public EditModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; } = new Evento();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.Include(e => e.Ubicacion).FirstOrDefaultAsync(m => m.IdEvento == id);
            if (evento == null)
            {
                return NotFound();
            }

            Evento = evento;
            ViewData["Ubicaciones"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "NombreUbicacion", Evento.IdUbicacion);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Ubicaciones"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "NombreUbicacion", Evento.IdUbicacion);
                return Page();
            }

            _context.Attach(Evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(Evento.IdEvento))
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

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.IdEvento == id);
        }
    }
}
