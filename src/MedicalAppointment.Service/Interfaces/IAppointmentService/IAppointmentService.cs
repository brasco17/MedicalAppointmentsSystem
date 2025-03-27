using MedicalAppointment.Service.DTOs.Appointment;

namespace MedicalAppointment.Service.Interfaces.IAppointmentService;

public interface IAppointmentService
{
    Task<AppointmentForResultDto> CreateAsync(AppointmentForCreationDto dto);
    Task<IEnumerable<AppointmentForResultDto>> GetAllAsync();
    Task<AppointmentForResultDto> GetByIdAsync(long id);
    Task<AppointmentForResultDto> UpdateAsync(long id, AppointmentForUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}