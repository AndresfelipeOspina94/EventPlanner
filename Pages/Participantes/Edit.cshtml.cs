using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Participantes
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
        public Participante Participante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participante = await _context.Participantes.FirstOrDefaultAsync(m => m.IdParticipante == id);

            if (Participante == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Participante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteExists(Participante.IdParticipante))
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

        private bool ParticipanteExists(int id)
        {
            return _context.Participantes.Any(e => e.IdParticipante == id);
        }
    }
}
