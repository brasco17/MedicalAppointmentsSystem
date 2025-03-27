using MedicalAppointment.Api.Helpers;
using MedicalAppointment.Service.DTOs.Appointment;
using MedicalAppointment.Service.Interfaces.IAppointmentService;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.AppointmentController;

public class AppointmentController : BaseController
{
    private readonly IAppointmentService _appointmentService;
    
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _appointmentService.GetAllAsync()
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var doctor = await _appointmentService.GetByIdAsync(id);
        return Ok(doctor);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _appointmentService.DeleteAsync(id)
        });
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AppointmentForCreationDto appointment)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _appointmentService.CreateAsync(appointment)
        });
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] AppointmentForUpdateDto appointment, [FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _appointmentService.UpdateAsync(id, appointment)
        });
    }
}