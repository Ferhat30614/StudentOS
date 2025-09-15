using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentOS.Api.Models;
using StudentOS.Api.Services;

namespace StudentOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    private readonly IGradeService _service;
    public GradesController(IGradeService service) => _service = service;

    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Add(Grade grade)
    {
        var g = await _service.CreateAsync(grade);
        return Ok(g);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Update(int id, Grade dto)
    {
        var grades = await _service.GetByEnrollmentIdAsync(dto.EnrollmentId);
        var g = grades.FirstOrDefault(x => x.Id == id);
        if (g == null) return NotFound();

        g.Value = dto.Value;
        await _service.UpdateAsync(g);
        return NoContent();
    }

    [HttpGet("enrollment/{enrollmentId:int}")]
    [Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetByEnrollment(int enrollmentId)
    {
        return Ok(await _service.GetByEnrollmentIdAsync(enrollmentId));
    }
}
                                            