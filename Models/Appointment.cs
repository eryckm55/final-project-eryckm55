using System.ComponentModel.DataAnnotations;

namespace final_project_eryckm55.Models;

public class Appointment
{
    public int AppointmentID { get; set; }

    [Required]
    [Display(Name = "Appointment Type")]
    [StringLength(80)]
    public string AppointmentType { get; set; } = string.Empty;

    [DataType(DataType.Currency)]
    public decimal Cost { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Appointment Date")]
    public DateTime Date { get; set; }

    // FK to Person (Owner)
    [Display(Name = "Owner")]
    public int PersonID { get; set; }

    public Person? Person { get; set; }

    // FK to Pet
    [Display(Name = "Pet")]
    public int PetID { get; set; }

    public Pet? Pet { get; set; }
}
