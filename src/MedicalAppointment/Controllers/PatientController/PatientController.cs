using MedicalAppointment.Api.Helpers;
using MedicalAppointment.Service.DTOs.Patient;
using MedicalAppointment.Service.Interfaces.IPatientService;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.PatientController;

public class PatientController : BaseController
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "success",
            Data = await _patientService.GetAllAsync()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
            {
                StatusCode = 200,
                Message = "success",
                Data = await _patientService.DeleteAsync(id)
            }

        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var patients = await _patientService.GetByIdAsync(id);
        return Ok(patients);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] PatientForCreationDto patient)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _patientService.CreateAsync(patient)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] PatientForUpdateDto patient, [FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _patientService.UpdateAsync(id, patient)
        });
    }
}