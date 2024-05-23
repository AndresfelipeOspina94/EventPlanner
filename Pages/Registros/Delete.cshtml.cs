using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Registros
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Registro = await _context.Registros.FindAsync(id);

            if (Registro != null)
            {
                _context.Registros.Remove(Registro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
