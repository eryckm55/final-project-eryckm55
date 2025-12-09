using System.ComponentModel.DataAnnotations;

namespace final_project_eryckm55.Models;

public class Pet
{
    public int PetID { get; set; }

    [Required]
    [Display(Name = "Pet Name")]
    [StringLength(60)]
    public string PetName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Pet Type")]
    [StringLength(40)]
    public string PetType { get; set; } = string.Empty;

    // FK to Person (Owner)
    [Display(Name = "Owner")]
    public int PersonID { get; set; }

    // Navigation
    public Person? Person { get; set; }

    // Navigation: appointments for this pet
    public List<Appointment> Appointments { get; set; } = new();
}
