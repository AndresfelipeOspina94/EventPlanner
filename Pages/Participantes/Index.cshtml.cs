using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Participantes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Participante> Participantes { get; set; } = new List<Participante>();

        public async Task OnGetAsync()
        {
            Participantes = await _context.Participantes.ToListAsync();
        }
    }
}
