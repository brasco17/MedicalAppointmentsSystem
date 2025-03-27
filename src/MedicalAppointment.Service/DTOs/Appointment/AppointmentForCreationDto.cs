namespace MedicalAppointment.Service.DTOs.Appointment;

public class AppointmentForCreationDto
{
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public DateTime Date { get; set; }
}