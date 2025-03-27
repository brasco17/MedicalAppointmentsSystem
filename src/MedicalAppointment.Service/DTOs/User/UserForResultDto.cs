using MedicalAppointment.Domain.Enums;

namespace MedicalAppointment.Service.DTOs.User;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; } 
}
