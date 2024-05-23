using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Ubicaciones
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
        public Ubicacion Ubicacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ubicacion = await _context.Ubicaciones.FindAsync(id);

            if (Ubicacion == null)
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

            _context.Attach(Ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(Ubicacion.IdUbicacion))
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

        private bool UbicacionExists(int id)
        {
            return _context.Ubicaciones.Any(e => e.IdUbicacion == id);
        }
    }
}
