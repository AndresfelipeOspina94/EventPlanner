using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Registros
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
        public Registro Registro { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Registro = await _context.Registros
                .Include(r => r.Evento)
                .Include(r => r.Participante)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);

            if (Registro == null)
            {
                return NotFound();
            }

            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento", Registro.IdEvento);
            ViewData["IdParticipante"] = new SelectList(_context.Participantes, "IdParticipante", "Nombre", Registro.IdParticipante);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento", Registro.IdEvento);
                ViewData["IdParticipante"] = new SelectList(_context.Participantes, "IdParticipante", "Nombre", Registro.IdParticipante);
                return Page();
            }

            _context.Attach(Registro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(Registro.IdRegistro))
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

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.IdRegistro == id);
        }
    }
}
