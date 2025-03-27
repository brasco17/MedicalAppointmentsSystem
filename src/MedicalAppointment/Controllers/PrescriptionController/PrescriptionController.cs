using MedicalAppointment.Api.Helpers;
using MedicalAppointment.Service.DTOs.Prescriptions;
using MedicalAppointment.Service.Interfaces.IPrescriptionService;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.Prescription.Controller;

public class PrescriptionController : BaseController
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "success",
            Data = await _prescriptionService.GetAllAsync()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
            {
                StatusCode = 200,
                Message = "success",
                Data = await _prescriptionService.DeleteAsync(id)
            }

        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var patients = await _prescriptionService.GetByIdAsync(id);
        return Ok(patients);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] PrescriptionForCreationDto prescription)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _prescriptionService.CreateAsync(prescription)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] PrescriptionForUpdateDto prescription, [FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _prescriptionService.UpdateAsync(id, prescription)
        });
    }
}