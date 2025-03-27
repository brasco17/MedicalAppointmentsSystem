using MedicalAppointment.Service.DTOs.User;

namespace MedicalAppointment.Service.Interfaces.IUserService;

public interface IUserService
{
    Task<UserForResultDto> RegisterAsync(UserForCreationDto dto);
    Task<UserForResultDto> UpdateAsync(long id, UserForUpdateDto dto);
    Task<UserForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> GetAllAsync();
    Task<bool> DeleteAsync(long id);
}
