using MedicalAppointment.Service.DTOs.Patient;
using MedicalAppointment.Service.Interfaces.IPatientService;
using AutoMapper;
using MedicalAppointment.Data.IRepositories;
using MedicalAppointment.Domain.Entities;

namespace MedicalAppointment.Service.Services.PatientService;

public class PatientService :IPatientService
{
    private readonly IRepository<Patient> _patientrepository;
    private readonly IMapper _mapper;

    public PatientService
        (
            IRepository<Patient> patientrepository, 
            IMapper mapper
        )
    {
        _patientrepository = patientrepository;
        _mapper = mapper;
    }
    public async Task<PatientForResultDto> CreateAsync(PatientForCreationDto dto)
    {
        var patient = _mapper.Map<Patient>(dto);
        var createdPatient = await _patientrepository.InsertAsync(patient);
        return _mapper.Map<PatientForResultDto>(createdPatient);
    }

    public async Task<IEnumerable<PatientForResultDto>> GetAllAsync()
    {
        var patients =  _patientrepository.GetAll();
        return _mapper.Map<IEnumerable<PatientForResultDto>>(patients);
    }

    public async Task<PatientForResultDto> GetByIdAsync(long id)
    {
        var patient = await _patientrepository.GetByIdAsync(id)
                      ?? throw new Exception("Patient not found");

        return _mapper.Map<PatientForResultDto>(patient);
    }

    public async Task<PatientForResultDto> UpdateAsync(long id, PatientForUpdateDto dto)
    {
        var existingPatient = await _patientrepository.GetByIdAsync(id) 
            ?? throw new Exception("Patient not found");
        _mapper.Map(dto, existingPatient);
        
        var updatedPatient = await _patientrepository.UpdateAsync(existingPatient);
        return _mapper.Map<PatientForResultDto>(updatedPatient);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existingPatient = await _patientrepository.GetByIdAsync(id)
                              ?? throw new Exception("Patient not found");

        await _patientrepository.RemoveAsync(id);
        return true;
        
    }
}