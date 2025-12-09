using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Appointments;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Appointment> Appointments { get; set; } = new();

    public async Task OnGetAsync()
    {
        Appointments = await _context.Appointments
            .Include(a => a.Person)
            .Include(a => a.Pet)
            .OrderBy(a => a.Date)
            .ToListAsync();
    }
}
