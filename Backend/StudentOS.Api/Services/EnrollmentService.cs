using StudentOS.Api.Models;
using StudentOS.Api.Repositories;

namespace StudentOS.Api.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repo;
    public EnrollmentService(IEnrollmentRepository repo) => _repo = repo;

    public async Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId) => await _repo.GetByCourseIdAsync(courseId);
    public async Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int studentId) => await _repo.GetByStudentIdAsync(studentId);
    public async Task<Enrollment?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

    public async Task<Enrollment> CreateAsync(Enrollment enrollment)
    {
        await _repo.AddAsync(enrollment);
        await _repo.SaveAsync();
        return enrollment;
    }

    public async Task DeleteAsync(Enrollment enrollment)
    {
        await _repo.DeleteAsync(enrollment);
        await _repo.SaveAsync();
    }
}
