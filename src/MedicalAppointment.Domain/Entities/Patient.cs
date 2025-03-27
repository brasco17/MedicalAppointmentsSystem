using MedicalAppointment.Domain.Commons;

namespace MedicalAppointment.Domain.Entities;

public class Patient : Auditable
{
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; } = string.Empty;
    
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
