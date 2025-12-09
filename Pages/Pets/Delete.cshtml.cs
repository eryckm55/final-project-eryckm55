using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Pets;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    public Pet Pet { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Pet = await _context.Pets
            .Include(p => p.Person)
            .FirstOrDefaultAsync(p => p.PetID == id);

        if (Pet == null) return RedirectToPage("./Index");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
