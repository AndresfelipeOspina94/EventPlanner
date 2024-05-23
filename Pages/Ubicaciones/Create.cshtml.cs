using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Ubicaciones
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
        public Ubicacion Ubicacion { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ubicaciones.Add(Ubicacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
