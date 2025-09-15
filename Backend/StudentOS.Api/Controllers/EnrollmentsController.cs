using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentOS.Api.Models;
using StudentOS.Api.Services;

namespace StudentOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly IEnrollmentService _service;
    public EnrollmentsController(IEnrollmentService service) => _service = service;

    [HttpPost]
    [Authorize(Roles = "Teacher,Admin")]
    public async Task<IActionResult> Enroll(Enrollment enrollment)
    {
        var e = await _service.CreateAsync(enrollment);
        return CreatedAtAction(nameof(GetById), new { id = e.Id }, e);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Teacher,Admin,Student")]
    public async Task<IActionResult> GetById(int id)
    {
        var e = await _service.GetByIdAsync(id);
        if (e == null) return NotFound();
        return Ok(e);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Teacher,Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _service.GetByIdAsync(id);
        if (e == null) return NotFound();
        await _service.DeleteAsync(e);
        return NoContent();
    }
}
