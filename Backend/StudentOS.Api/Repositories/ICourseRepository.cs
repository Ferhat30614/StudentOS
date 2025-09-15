using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<IEnumerable<Course>> GetByTeacherIdAsync(int teacherId);
}
