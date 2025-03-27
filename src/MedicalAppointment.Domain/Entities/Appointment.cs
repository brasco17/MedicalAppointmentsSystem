using MedicalAppointment.Domain.Commons;
using MedicalAppointment.Domain.Enums;

namespace MedicalAppointment.Domain.Entities;

public class Appointment : Auditable
{
    public DateTime Date { get; set; }
    public AppointmentStatus Status { get; set; }
    
    public long PatientId { get; set; }
    public Patient Patient { get; set; }
    
    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}