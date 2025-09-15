using Microsoft.EntityFrameworkCore;
using StudentOS.Api.Data;
using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Course>> GetByTeacherIdAsync(int teacherId)
    {
        return await _context.Courses
            .Include(c => c.Teacher)
            .Where(c => c.TeacherId == teacherId)
            .ToListAsync();
    }
}
