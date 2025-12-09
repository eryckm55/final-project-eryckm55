using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Pets;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Pet Pet { get; set; }

    public List<Person> People { get; set; } = new();

    public async Task OnGetAsync()
    {
        People = await _context.People.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            People = await _context.People.ToListAsync();
            return Page();
        }

        _context.Pets.Add(Pet);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
