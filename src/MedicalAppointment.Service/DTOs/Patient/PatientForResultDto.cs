namespace MedicalAppointment.Service.DTOs.Patient;

public class PatientForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; } = string.Empty;  
}