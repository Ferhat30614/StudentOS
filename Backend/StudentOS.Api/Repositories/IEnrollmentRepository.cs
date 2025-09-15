using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public interface IEnrollmentRepository : IGenericRepository<Enrollment>
{
    Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId);
    Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int studentId);
}
