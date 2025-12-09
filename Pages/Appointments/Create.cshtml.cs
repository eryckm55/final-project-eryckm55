using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Appointments;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Appointment Appointment { get; set; }

    public List<SelectListItem> Pets { get; set; }
    public List<SelectListItem> People { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        Pets = await _context.Pets
            .Select(p => new SelectListItem 
            { 
                Value = p.PetID.ToString(), 
                Text = p.PetName + " (" + p.PetType + ")" 
            })
            .ToListAsync();

        People = await _context.People
            .Select(o => new SelectListItem 
            { 
                Value = o.PersonID.ToString(), 
                Text = o.Name 
            })
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Reload dropdowns
            await OnGetAsync();
            return Page();
        }

        _context.Appointments.Add(Appointment);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
