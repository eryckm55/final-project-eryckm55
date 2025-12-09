using final_project_eryckm55.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project_eryckm55.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Ensure database exists and matches model
        context.Database.EnsureCreated();

        if (context.People.Any())
        {
            // Already seeded
            return;
        }

        // Seed People
        var person1 = new Person { Name = "Eryck Mendoza" };
        var person2 = new Person { Name = "Sarah Connor" };

        context.People.AddRange(person1, person2);
        context.SaveChanges();

        // Seed Pets
        var pet1 = new Pet { PetName = "Buddy", PetType = "Dog", PersonID = person1.PersonID };
        var pet2 = new Pet { PetName = "Luna", PetType = "Cat", PersonID = person1.PersonID };
        var pet3 = new Pet { PetName = "Rex", PetType = "Dog", PersonID = person2.PersonID };

        context.Pets.AddRange(pet1, pet2, pet3);
        context.SaveChanges();

        // Seed Appointments
        var appt1 = new Appointment
        {
            AppointmentType = "Wellness Check",
            Cost = 75.00M,
            Date = DateTime.Today.AddDays(2),
            PersonID = person1.PersonID,
            PetID = pet1.PetID
        };

        var appt2 = new Appointment
        {
            AppointmentType = "Vaccination",
            Cost = 60.00M,
            Date = DateTime.Today.AddDays(5),
            PersonID = person1.PersonID,
            PetID = pet2.PetID
        };

        var appt3 = new Appointment
        {
            AppointmentType = "Surgery Consultation",
            Cost = 200.00M,
            Date = DateTime.Today.AddDays(7),
            PersonID = person2.PersonID,
            PetID = pet3.PetID
        };

        context.Appointments.AddRange(appt1, appt2, appt3);
        context.SaveChanges();
    }
}
