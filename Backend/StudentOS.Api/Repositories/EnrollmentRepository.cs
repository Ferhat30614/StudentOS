using Microsoft.EntityFrameworkCore;
using StudentOS.Api.Data;
using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId) =>
        await _context.Enrollments.Include(e => e.Student).Where(e => e.CourseId == courseId).ToListAsync();

    public async Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int studentId) =>
        await _context.Enrollments.Include(e => e.Course).Where(e => e.StudentId == studentId).ToListAsync();
}
