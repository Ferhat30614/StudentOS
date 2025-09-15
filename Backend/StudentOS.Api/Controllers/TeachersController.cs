using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentOS.Api.Models;
using StudentOS.Api.Services;
using System.Security.Claims;

namespace StudentOS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeachersController(ITeacherService service)
    {
        _service = service;
    }

    // Admin  tüm öğretmenleri listele
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var list = await _service.GetAllAsync();
        return Ok(list);
    }

    // Admintek öğretmen
    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> GetById(int id)
    {
        var t = await _service.GetByIdAsync(id);
        if (t == null) return NotFound();
        return Ok(t);
    }

    // Admin yeni öğretmen oluştur
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Teacher teacher)
    {
        var t = await _service.CreateAsync(teacher);
        return CreatedAtAction(nameof(GetById), new { id = t.Id }, t);
    }

    // Admin güncelle
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, Teacher dto)
    {
        var t = await _service.GetByIdAsync(id);
        if (t == null) return NotFound();

        t.Title = dto.Title;
        await _service.UpdateAsync(t);
        return NoContent();
    }

    // Adminsil
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var t = await _service.GetByIdAsync(id);
        if (t == null) return NotFound();

        await _service.DeleteAsync(t);
        return NoContent();
    }

    // Teacher kendi kaydını gör
    [HttpGet("me")]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Me()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var t = await _service.GetByUserIdAsync(userId);
        if (t == null) return NotFound("Öğretmen kaydı bulunamadı.");
        return Ok(t);
    }
}
