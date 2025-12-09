using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace final_project_eryckm55.Pages.People;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    public Person? Person { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Person = await _context.People.FindAsync(id);
        if (Person == null)
            return RedirectToPage("./Index");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var person = await _context.People.FindAsync(id);
        if (person != null)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
