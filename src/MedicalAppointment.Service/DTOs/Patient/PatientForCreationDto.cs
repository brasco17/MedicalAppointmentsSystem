using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.Service.DTOs.Patient;

public class PatientForCreationDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [RegularExpression(@"^\+998\d{9}$", ErrorMessage = "Invalid phone number format. It should be like +998901234567.")]
    public string Phone { get; set; } = string.Empty;
}