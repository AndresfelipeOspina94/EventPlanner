using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Ubicaciones
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Ubicacion> Ubicaciones { get; set; } = new List<Ubicacion>();

        public async Task OnGetAsync()
        {
            Ubicaciones = await _context.Ubicaciones.ToListAsync();
        }
    }
}
