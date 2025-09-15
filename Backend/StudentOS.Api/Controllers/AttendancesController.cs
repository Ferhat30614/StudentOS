using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentOS.Api.Models;
using StudentOS.Api.Services;

namespace StudentOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendancesController : ControllerBase
{
    private readonly IAttendanceService _service;
    public AttendancesController(IAttendanceService service) => _service = service;

    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Add(Attendance attendance)
    {
        var a = await _service.CreateAsync(attendance);
        return Ok(a);
    }

    [HttpGet("enrollment/{enrollmentId:int}")]
    [Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetByEnrollment(int enrollmentId)
    {
        return Ok(await _service.GetByEnrollmentIdAsync(enrollmentId));
    }
}
