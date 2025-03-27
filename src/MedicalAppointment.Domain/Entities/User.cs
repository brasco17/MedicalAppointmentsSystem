using MedicalAppointment.Domain.Commons;
using MedicalAppointment.Domain.Enums;

namespace MedicalAppointment.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string passwordHash { get; set; }
    public UserRole Role { get; set; }
}