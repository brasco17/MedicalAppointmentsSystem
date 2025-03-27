using MedicalAppointment.Service.DTOs.Prescriptions;

namespace MedicalAppointment.Service.Interfaces.IPrescriptionService;

public interface IPrescriptionService
{
    Task<PrescriptionForResultDto> CreateAsync(PrescriptionForCreationDto dto);
    Task<IEnumerable<PrescriptionForResultDto>> GetAllAsync();
    Task<PrescriptionForResultDto> GetByIdAsync(long id);
    Task<PrescriptionForResultDto> UpdateAsync(long id, PrescriptionForUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}