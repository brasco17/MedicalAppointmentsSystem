using MedicalAppointment.Service.DTOs.Patient;

namespace MedicalAppointment.Service.Interfaces.IPatientService;

public interface IPatientService
{
    Task<PatientForResultDto> CreateAsync(PatientForCreationDto dto);
    Task<IEnumerable<PatientForResultDto>> GetAllAsync();
    Task<PatientForResultDto> GetByIdAsync(long id);
    Task<PatientForResultDto> UpdateAsync(long id, PatientForUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}