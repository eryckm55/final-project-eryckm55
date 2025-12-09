using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Pets;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Pet> Pets { get; set; } = new();

    public async Task OnGetAsync()
    {
        Pets = await _context.Pets
            .Include(p => p.Person)  // owner
            .ToListAsync();
    }
}
