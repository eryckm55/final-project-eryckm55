using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Pets;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;
    public EditModel(AppDbContext context) { _context = context; }

    [BindProperty]
    public Pet Pet { get; set; }

    public List<Person> People { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Pet = await _context.Pets.FindAsync(id);
        if (Pet == null) return RedirectToPage("./Index");

        People = await _context.People.ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            People = await _context.People.ToListAsync();
            return Page();
        }

        _context.Attach(Pet).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
