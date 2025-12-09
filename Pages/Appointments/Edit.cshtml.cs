using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Appointments;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Appointment Appointment { get; set; }

    public List<SelectListItem> Pets { get; set; }
    public List<SelectListItem> People { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Appointment = await _context.Appointments
            .Include(a => a.Pet)
            .Include(a => a.Person)
            .FirstOrDefaultAsync(a => a.AppointmentID == id);

        if (Appointment == null)
            return RedirectToPage("./Index");

        Pets = await _context.Pets
            .Select(p => new SelectListItem
            {
                Value = p.PetID.ToString(),
                Text = $"{p.PetName} ({p.PetType})"
            })
            .ToListAsync();

        People = await _context.People
            .Select(p => new SelectListItem
            {
                Value = p.PersonID.ToString(),
                Text = p.Name
            })
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync(Appointment.AppointmentID);
            return Page();
        }

        _context.Attach(Appointment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Appointments.Any(a => a.AppointmentID == Appointment.AppointmentID))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }
}
