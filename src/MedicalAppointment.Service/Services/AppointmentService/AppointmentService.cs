using AutoMapper;
using MedicalAppointment.Data.IRepositories;
using MedicalAppointment.Domain.Entities;
using MedicalAppointment.Domain.Enums;
using MedicalAppointment.Service.DTOs.Appointment;
using MedicalAppointment.Service.Interfaces.IAppointmentService;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Service.AppointmentService;

public class AppointmentService : IAppointmentService
{
    public readonly IRepository<Appointment> _appointmentRepository;
    public readonly IRepository<Doctor> _doctorRepository;
    public readonly IRepository<Patient> _patientRepository;
    public readonly IMapper _mapper;

    public AppointmentService
    (
        IRepository<Appointment> appointmentRepository, 
        IRepository<Doctor> doctorRepository,
        IRepository<Patient> patientRepository, 
        IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
    }
    public async Task<AppointmentForResultDto> CreateAsync(AppointmentForCreationDto dto)
    {
        var existDoctor = await _doctorRepository.GetByIdAsync(dto.DoctorId)
            ?? throw new Exception("Doctor not found");
        var existPatient = await _patientRepository.GetByIdAsync(dto.PatientId)
            ?? throw new Exception("Patient not found");
        //doctor must be free
        bool isDoctorBusy = await _appointmentRepository.GetAll()
            .AnyAsync(x=>
                x.DoctorId == dto.DoctorId &&
                x.Date == dto.Date &&
                x.Status == AppointmentStatus.Scheduled);

        if (isDoctorBusy)
            throw new Exception("Doctor is already booked at this time.");
        
        //patient must be free
        bool isPatienBusy = await _appointmentRepository.GetAll()
            .AnyAsync(x=>
                x.PatientId == dto.PatientId &&
                x.Date == dto.Date &&
                x.Status == AppointmentStatus.Scheduled);
        if(isPatienBusy)
            throw new Exception("Patient has already been booked at this time.");
        
        //time must be in the future
        if (dto.Date <= DateTime.UtcNow)
            throw new Exception("Appointment time must be in the future.");
        
        var appointment = _mapper.Map<Appointment>(dto);
        var createdAppointment = await _appointmentRepository.InsertAsync(appointment);

        return _mapper.Map<AppointmentForResultDto>(createdAppointment);
    }

    public async Task<IEnumerable<AppointmentForResultDto>> GetAllAsync()
    {
        var appointments = _appointmentRepository.GetAll()
            ?? throw new Exception("Appointments not found");
        
        return _mapper.Map<IEnumerable<AppointmentForResultDto>>(appointments);
    }

    public async Task<AppointmentForResultDto> GetByIdAsync(long id)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(id)
            ?? throw new Exception("Appointment not found");
        
        return _mapper.Map<AppointmentForResultDto>(appointment);
    }

    public async Task<AppointmentForResultDto> UpdateAsync(long id, AppointmentForUpdateDto dto)
    {
        var existingAppointment = await _appointmentRepository.GetByIdAsync(id) 
                                  ?? throw new Exception("Appointment not found");
        
        if (existingAppointment.Status == AppointmentStatus.Completed)
            throw new Exception("Completed appointments cannot be updated.");

        
        if (dto.DoctorId != existingAppointment.DoctorId)
        {
            bool isDoctorBusy = await _appointmentRepository.GetAll().AnyAsync(a =>
                a.DoctorId == dto.DoctorId &&
                a.Date == dto.Date &&
                a.Status == AppointmentStatus.Scheduled);

            if (isDoctorBusy)
                throw new Exception("Doctor is already booked at this time.");
        }

        _mapper.Map(dto, existingAppointment);
        var updatedAppointment = await _appointmentRepository.UpdateAsync(existingAppointment);
    
        return _mapper.Map<AppointmentForResultDto>(updatedAppointment);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(id) 
                          ?? throw new Exception("Appointment not found");

        if (appointment.Status == AppointmentStatus.Completed)
            throw new Exception("Completed appointments cannot be deleted.");

        await _appointmentRepository.RemoveAsync(id);
        return true;
    }

}