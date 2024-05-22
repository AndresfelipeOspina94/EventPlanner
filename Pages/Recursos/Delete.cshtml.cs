using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Recursos
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public DeleteModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recurso Recurso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recurso = await _context.Recursos
                .Include(r => r.Evento)
                .FirstOrDefaultAsync(m => m.IdRecurso == id);

            if (Recurso == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recurso = await _context.Recursos.FindAsync(id);

            if (Recurso != null)
            {
                _context.Recursos.Remove(Recurso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
