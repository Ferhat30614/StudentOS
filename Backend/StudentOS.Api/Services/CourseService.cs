using StudentOS.Api.Models;
using StudentOS.Api.Repositories;

namespace StudentOS.Api.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repo;
    public CourseService(ICourseRepository repo) => _repo = repo;

    public async Task<IEnumerable<Course>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<Course?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task<IEnumerable<Course>> GetByTeacherIdAsync(int teacherId) => await _repo.GetByTeacherIdAsync(teacherId);

    public async Task<Course> CreateAsync(Course course)
    {
        await _repo.AddAsync(course);
        await _repo.SaveAsync();
        return course;
    }

    public async Task UpdateAsync(Course course)
    {
        await _repo.UpdateAsync(course);
        await _repo.SaveAsync();
    }

    public async Task DeleteAsync(Course course)
    {
        await _repo.DeleteAsync(course);
        await _repo.SaveAsync();
    }
}
