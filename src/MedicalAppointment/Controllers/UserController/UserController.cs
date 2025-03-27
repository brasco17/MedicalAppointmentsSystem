using MedicalAppointment.Api.Helpers;
using MedicalAppointment.Service.DTOs.User;
using MedicalAppointment.Service.Interfaces.IUserService;
using Microsoft.AspNetCore.Mvc;


namespace MedicalAppointment.Api.Controllers.UserController;

public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.GetAllAsync()
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.DeleteAsync(id)
        });
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] UserForCreationDto user)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.RegisterAsync(user)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UserForUpdateDto user, [FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.UpdateAsync(id, user)
        });
    }
}
