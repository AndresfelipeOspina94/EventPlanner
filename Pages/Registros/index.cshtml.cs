using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Registros
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Registro> Registros { get; set; } = new List<Registro>();

        public async Task OnGetAsync()
        {
            Registros = await _context.Registros
                .Include(r => r.Evento)
                .Include(r => r.Participante)
                .ToListAsync();
        }
    }
}
