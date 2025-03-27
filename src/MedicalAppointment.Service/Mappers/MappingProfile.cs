using AutoMapper;
using MedicalAppointment.Domain.Entities;
using MedicalAppointment.Service.DTOs.Appointment;
using MedicalAppointment.Service.DTOs.Doctor;
using MedicalAppointment.Service.DTOs.Patient;
using MedicalAppointment.Service.DTOs.Prescriptions;
using MedicalAppointment.Service.DTOs.User;

namespace MedicalAppointment.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User mapping
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<UserForCreationDto, User>().ReverseMap();
        CreateMap<UserForUpdateDto, User>().ReverseMap();

        // Doctor mapping
        CreateMap<Doctor, DoctorForResultDto>().ReverseMap();
        CreateMap<DoctorForCreationDto, Doctor>().ReverseMap();
        CreateMap<DoctorForUpdateDto, Doctor>().ReverseMap();

        // Patient mapping
        CreateMap<Patient, PatientForResultDto>().ReverseMap();
        CreateMap<PatientForCreationDto, Patient>().ReverseMap();
        CreateMap<PatientForUpdateDto, Patient>().ReverseMap();

        // Appointment mapping
        CreateMap<Appointment, AppointmentForResultDto>().ReverseMap();
        CreateMap<AppointmentForCreationDto, Appointment>().ReverseMap();
        CreateMap<AppointmentForUpdateDto, Appointment>().ReverseMap();

        // Prescription mapping
        CreateMap<Prescription, PrescriptionForResultDto>().ReverseMap();
        CreateMap<PrescriptionForCreationDto, Prescription>().ReverseMap();
        CreateMap<PrescriptionForUpdateDto, Prescription>().ReverseMap();
    }
}