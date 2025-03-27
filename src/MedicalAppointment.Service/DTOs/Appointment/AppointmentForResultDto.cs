namespace MedicalAppointment.Service.DTOs.Appointment;

public class AppointmentForResultDto
{
    public long Id { get; set; }
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = string.Empty;

}