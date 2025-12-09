using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.People;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Person> People { get; set; } = new();

    public async Task OnGetAsync()
    {
        People = await _context.People
            .Include(p => p.Pets)      // count pets per person
            .ToListAsync();
    }
}
