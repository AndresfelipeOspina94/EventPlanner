using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Recursos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Recurso> Recursos { get; set; } = new List<Recurso>();

        public async Task OnGetAsync()
        {
            Recursos = await _context.Recursos
                .Include(r => r.Evento)
                .ToListAsync();
        }
    }
}
