using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Eventos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Evento> Eventos { get; set; } = new List<Evento>();

        public async Task OnGetAsync()
        {
            Eventos = await _context.Eventos
                .Include(e => e.Ubicacion)
                .ToListAsync();
        }
    }
}
