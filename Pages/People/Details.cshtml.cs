using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.People;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Person? Person { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Person = await _context.People
            .Include(p => p.Pets)
            .FirstOrDefaultAsync(p => p.PersonID == id);

        if (Person == null)
            return RedirectToPage("./Index");

        return Page();
    }
}
