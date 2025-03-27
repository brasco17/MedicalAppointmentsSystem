namespace MedicalAppointment.Service.DTOs.Prescriptions;

public class PrescriptionForUpdateDto 
{
    public long DoctorId { get; set; }
    public string Medicine { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
}