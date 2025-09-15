using StudentOS.Api.Models;

namespace StudentOS.Api.Services;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id);
    Task<IEnumerable<Course>> GetByTeacherIdAsync(int teacherId);
    Task<Course> CreateAsync(Course course);
    Task UpdateAsync(Course course);
    Task DeleteAsync(Course course);
}
