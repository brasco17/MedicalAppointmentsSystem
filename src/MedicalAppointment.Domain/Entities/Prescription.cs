using MedicalAppointment.Domain.Commons;

namespace MedicalAppointment.Domain.Entities;

public class Prescription : Auditable
{
    public string Medicine { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    
    public long AppointmentId { get; set; }
    public long DoctorId { get; set; }
    public Appointment Appointment { get; set; }
}