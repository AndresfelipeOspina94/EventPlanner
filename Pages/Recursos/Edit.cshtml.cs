using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Recursos
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
        public Recurso Recurso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recurso = await _context.Recursos.FirstOrDefaultAsync(m => m.IdRecurso == id);

            if (Recurso == null)
            {
                return NotFound();
            }

            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento", Recurso.IdEvento);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento", Recurso.IdEvento);
                return Page();
            }

            _context.Attach(Recurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(Recurso.IdRecurso))
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

        private bool RecursoExists(int id)
        {
            return _context.Recursos.Any(e => e.IdRecurso == id);
        }
    }
}
