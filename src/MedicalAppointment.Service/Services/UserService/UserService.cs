using AutoMapper;
using MedicalAppointment.Data.IRepositories;
using MedicalAppointment.Domain.Entities;
using MedicalAppointment.Service.DTOs.User;
using MedicalAppointment.Service.Interfaces.IUserService;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Service.Services.UserService;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserForResultDto> RegisterAsync(UserForCreationDto dto)
    {
        
        var existingUser =  _userRepository.GetAll().AnyAsync(x=>x.Email == dto.Email)
            ?? throw new Exception("User already exists");
        
        var user = _mapper.Map<User>(dto);
        user.CreatedOn = DateTime.UtcNow;
        
        var createdUser = await _userRepository.InsertAsync(user);
        
        return _mapper.Map<UserForResultDto>(createdUser);
    }

    public async Task<UserForResultDto> UpdateAsync(long id, UserForUpdateDto dto)
    {
        var existingUser = await _userRepository.GetByIdAsync(id)
            ?? throw new Exception("User not found");
        
        _mapper.Map(dto, existingUser);
        existingUser.ModifiedOn = DateTime.UtcNow;

        var updatedUser = await _userRepository.UpdateAsync(existingUser);

        return _mapper.Map<UserForResultDto>(updatedUser);
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id)
            ?? throw new Exception("User not found");

        return _mapper.Map<UserForResultDto>(user);
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        var users =  _userRepository.GetAll();
        return users.Select(user => _mapper.Map<UserForResultDto>(user));
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id)
            ?? throw new Exception("User not found");

        return await _userRepository.RemoveAsync(id);
    }
}
