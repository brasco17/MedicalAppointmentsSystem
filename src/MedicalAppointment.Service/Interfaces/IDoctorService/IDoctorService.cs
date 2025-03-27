using MedicalAppointment.Service.DTOs.Doctor;

namespace MedicalAppointment.Service.Interfaces.IDoctorService;

public interface IDoctorService
{
    Task<DoctorForResultDto> CreateAsync(DoctorForCreationDto dto);
    Task<IEnumerable<DoctorForResultDto>> GetAllAsync();
    Task<DoctorForResultDto> GetByIdAsync(long id);
    Task<DoctorForResultDto> UpdateAsync(long id, DoctorForUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}