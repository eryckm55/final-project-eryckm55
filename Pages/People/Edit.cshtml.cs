using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace final_project_eryckm55.Pages.People;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Person? Person { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Person = await _context.People.FindAsync(id);
        if (Person == null)
            return RedirectToPage("./Index");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        if (Person != null)
        {
            _context.People.Update(Person);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("./Index");
    }
}
