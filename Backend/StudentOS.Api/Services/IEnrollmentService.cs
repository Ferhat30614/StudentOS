using StudentOS.Api.Models;

namespace StudentOS.Api.Services;

public interface IEnrollmentService
{
    Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId);
    Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int studentId);
    Task<Enrollment?> GetByIdAsync(int id);
    Task<Enrollment> CreateAsync(Enrollment enrollment);
    Task DeleteAsync(Enrollment enrollment);
}
