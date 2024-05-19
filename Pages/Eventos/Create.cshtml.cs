using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventPlanner.Pages.Eventos
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
        public Evento Evento { get; set; } = new Evento();

        public IActionResult OnGet()
        {
            ViewData["Ubicaciones"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "NombreUbicacion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Ubicaciones"] = new SelectList(_context.Ubicaciones, "IdUbicacion", "NombreUbicacion");
                return Page();
            }

            _context.Eventos.Add(Evento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
