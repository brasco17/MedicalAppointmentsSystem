using MedicalAppointment.Domain.Commons;

namespace MedicalAppointment.Domain.Entities;

public class Doctor : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); // null oldini olish uchun

}