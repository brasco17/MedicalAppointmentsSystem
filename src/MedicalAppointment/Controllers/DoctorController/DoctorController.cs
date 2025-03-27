using MedicalAppointment.Api.Helpers;
using MedicalAppointment.Service.DTOs.Doctor;
using MedicalAppointment.Service.Interfaces.IDoctorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.DoctorController;

    //[Authorize(Roles = "Admin")]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _doctorService;
    
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _doctorService.GetAllAsync()
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            return Ok(doctor);
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _doctorService.DeleteAsync(id)
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DoctorForCreationDto doctor)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _doctorService.CreateAsync(doctor)
            });
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] DoctorForUpdateDto doctor, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _doctorService.UpdateAsync(id, doctor)
            });
        }
    }

