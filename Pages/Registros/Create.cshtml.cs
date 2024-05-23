using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Registros
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public CreateModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Registro Registro { get; set; }

        public IActionResult OnGet()
        {
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento");
            ViewData["IdParticipante"] = new SelectList(_context.Participantes, "IdParticipante", "Nombre");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NombreEvento");
                ViewData["IdParticipante"] = new SelectList(_context.Participantes, "IdParticipante", "Nombre");
                return Page();
            }

            _context.Registros.Add(Registro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
