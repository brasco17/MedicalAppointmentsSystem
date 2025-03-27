using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicalAppointment.Data.IRepositories;
using MedicalAppointment.Domain.Entities;
using MedicalAppointment.Domain.Enums;
using MedicalAppointment.Service.DTOs.Prescriptions;
using MedicalAppointment.Service;
using MedicalAppointment.Service.Interfaces;
using MedicalAppointment.Service.Interfaces.IPrescriptionService;
using MedicalAppointment.Service.Interfaces.IUserService;

namespace MedicalAppointment.Service.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IRepository<Prescription> _prescriptionRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PrescriptionService
        (
            IRepository<Prescription> prescriptionRepository, 
            IUserService userService, 
            IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _userService = userService;
            _mapper = mapper;
        }
        
        public async Task<PrescriptionForResultDto> CreateAsync(PrescriptionForCreationDto dto)
        {
            if (!await UserIsDoctorOrAdmin(dto.DoctorId))
                throw new Exception("You are not allowed to create prescriptions.");

            var prescription = _mapper.Map<Prescription>(dto);
            prescription.CreatedOn = DateTime.UtcNow;

            var createdPrescription = await _prescriptionRepository.InsertAsync(prescription);
            return _mapper.Map<PrescriptionForResultDto>(createdPrescription);
        }
        
        public async Task<PrescriptionForResultDto> UpdateAsync(long id, PrescriptionForUpdateDto dto)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id)
                ?? throw new Exception("Prescription not found.");

            if (!await UserIsDoctorOrAdmin(prescription.DoctorId))
                throw new Exception("You are not allowed to update this prescription.");

            _mapper.Map(dto, prescription);
            prescription.ModifiedOn = DateTime.UtcNow;

            var updatedPrescription = await _prescriptionRepository.UpdateAsync(prescription);
            return _mapper.Map<PrescriptionForResultDto>(updatedPrescription);
        }

        public async Task<PrescriptionForResultDto> GetByIdAsync(long id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id)
                ?? throw new Exception("Prescription not found.");

            return _mapper.Map<PrescriptionForResultDto>(prescription);
        }
        
        public async Task<IEnumerable<PrescriptionForResultDto>> GetAllAsync()
        {
            var prescriptions =  _prescriptionRepository.GetAll();
            return _mapper.Map<IEnumerable<PrescriptionForResultDto>>(prescriptions);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id)
                ?? throw new Exception("Prescription not found.");
            
            if (!await UserIsDoctorOrAdmin(prescription.DoctorId))
                throw new Exception("You are not allowed to delete this prescription.");

            return await _prescriptionRepository.RemoveAsync(id);
        }
        
        private async Task<bool> UserIsDoctorOrAdmin(long doctorId)
        {
            var user = await _userService.GetByIdAsync(doctorId);

            if (user == null)
                return false;

            return user.Role == UserRole.Admin || user.Role == UserRole.Doctor;
        }
    }
}
