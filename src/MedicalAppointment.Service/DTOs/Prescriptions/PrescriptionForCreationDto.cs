namespace MedicalAppointment.Service.DTOs.Prescriptions;

public class PrescriptionForCreationDto
{
    public long DoctorId { get; set; }
    public long AppointmentId { get; set; }
    public string Medicine { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
}