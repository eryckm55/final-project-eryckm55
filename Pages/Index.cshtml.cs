using final_project_eryckm55.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public int TotalPeople { get; set; }
    public int TotalPets { get; set; }
    public int TotalAppointments { get; set; }

    public async Task OnGetAsync()
    {
        TotalPeople = await _context.People.CountAsync();
        TotalPets = await _context.Pets.CountAsync();
        TotalAppointments = await _context.Appointments.CountAsync();
    }
}
