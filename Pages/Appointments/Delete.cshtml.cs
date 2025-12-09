using final_project_eryckm55.Data;
using final_project_eryckm55.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Pages.Appointments;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Appointment Appointment { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Appointment = await _context.Appointments
            .Include(a => a.Pet)
            .Include(a => a.Person)
            .FirstOrDefaultAsync(a => a.AppointmentID == id);

        if (Appointment == null)
            return RedirectToPage("./Index");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var appt = await _context.Appointments.FindAsync(Appointment.AppointmentID);

        if (appt == null)
            return RedirectToPage("./Index");

        _context.Appointments.Remove(appt);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
