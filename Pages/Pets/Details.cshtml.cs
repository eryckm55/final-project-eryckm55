using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Pets;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;
    public DetailsModel(AppDbContext context) { _context = context; }

    public Pet Pet { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Pet = await _context.Pets
            .Include(p => p.Person)
            .FirstOrDefaultAsync(p => p.PetID == id);

        if (Pet == null) return RedirectToPage("./Index");
        return Page();
    }
}
