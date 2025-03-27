using AutoMapper;
using MedicalAppointment.Data.IRepositories;
using MedicalAppointment.Domain.Entities;
using MedicalAppointment.Domain.Enums;
using MedicalAppointment.Service.DTOs.Doctor;
using MedicalAppointment.Service.Interfaces.IDoctorService;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Service.Services.DoctorService;

public class DoctorService : IDoctorService

{
    private readonly IRepository<Doctor> _doctorRepository;
    private readonly IRepository<Appointment> _appointmentRepository;
    private readonly IMapper _mapper;

    public DoctorService
        (
            IRepository<Doctor> doctorRepository,
            IRepository<Appointment> 
            appointmentRepository,
            IMapper mapper
        )
    {
        _doctorRepository = doctorRepository;
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    
    public async Task<DoctorForResultDto> CreateAsync(DoctorForCreationDto dto)
    {
        //existing doctor with the same name and specialty
        bool existDoctor = await _doctorRepository.GetAll().AnyAsync(p => p.Specialty == dto.Specialty && p.Name == dto.Name);
        if (existDoctor)
            throw new Exception("A doctor with the same name and specialty already exists");
        
        var doctor = _mapper.Map<Doctor>(dto);
        var createdDoctor = await _doctorRepository.InsertAsync(doctor);
        return _mapper.Map<DoctorForResultDto>(createdDoctor);
    }

    public async Task<IEnumerable<DoctorForResultDto>> GetAllAsync()
    {
        var doctors = _doctorRepository.GetAll();
        return _mapper.Map<IEnumerable<DoctorForResultDto>>(doctors);
    }

    public async Task<DoctorForResultDto> GetByIdAsync(long id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id)
                     ?? throw new Exception("Doctor not found");

        return _mapper.Map<DoctorForResultDto>(doctor);
    }

    public async Task<DoctorForResultDto> UpdateAsync(long id, DoctorForUpdateDto dto)
    {
        var existingDoctor = await _doctorRepository.GetByIdAsync(id)
                             ?? throw new Exception("Doctor not found");
        
        _mapper.Map(dto, existingDoctor);
        var updatedDoctor = await _doctorRepository.UpdateAsync(existingDoctor);
        return _mapper.Map<DoctorForResultDto>(updatedDoctor);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existingDoctor =  await _doctorRepository.GetByIdAsync(id)
                             ?? throw new Exception("Doctor not found");

        //  checking doctor's appointments
        bool hasAppointments = await _appointmentRepository
            .GetAll()
            .AnyAsync(a => a.DoctorId == id && a.Status != AppointmentStatus.Completed);
        if (hasAppointments)
            throw new Exception("Doctor has an active appointment");
        
         await _doctorRepository.RemoveAsync(id);
        return true;
    }
}