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
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public DeleteModel(EventPlannerContext context)
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

            Ubicacion = await _context.Ubicaciones.FirstOrDefaultAsync(m => m.IdUbicacion == id);

            if (Ubicacion == null)
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

            Ubicacion = await _context.Ubicaciones.FindAsync(id);

            if (Ubicacion != null)
            {
                _context.Ubicaciones.Remove(Ubicacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
