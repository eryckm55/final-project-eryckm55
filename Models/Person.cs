using System.ComponentModel.DataAnnotations;

namespace final_project_eryckm55.Models;

public class Person
{
    public int PersonID { get; set; }

    [Required]
    [StringLength(60)]
    [Display(Name = "Owner Name")]
    public string Name { get; set; } = string.Empty;


    // Navigation: a person can have many pets and many appointments
    public List<Pet> Pets { get; set; } = new();
    public List<Appointment> Appointments { get; set; } = new();
}
