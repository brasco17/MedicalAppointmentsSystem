namespace MedicalAppointment.Service.DTOs.Patient;

public class PatientForUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; } = string.Empty;   
}