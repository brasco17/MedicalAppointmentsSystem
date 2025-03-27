using MedicalAppointment.Domain.Enums;

namespace MedicalAppointment.Service.DTOs.User;

public class UserForCreationDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } 
    public UserRole Role { get; set; } 
}