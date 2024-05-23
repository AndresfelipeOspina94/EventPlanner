using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Pages.Eventos
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) 
        {
            if (id == null || _context.Eventos == null) 
            {
                return NotFound(); 
            }

            var evento = await _context.Eventos.FindAsync(id); 
             
            if (evento != null) 
            {
                Evento = evento; 
                _context.Eventos.Remove(Evento); 
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
