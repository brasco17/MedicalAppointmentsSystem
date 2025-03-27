using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.Service.DTOs.Doctor;

public class DoctorForCreationDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Specialty { get; set; } = string.Empty;
}