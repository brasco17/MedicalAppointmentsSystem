namespace MedicalAppointment.Service.DTOs.Appointment;

public class AppointmentForUpdateDto
{
    public long DoctorId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = string.Empty;
}