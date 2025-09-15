using StudentOS.Api.Models;
using StudentOS.Api.Repositories;

namespace StudentOS.Api.Services;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _repo;
    public GradeService(IGradeRepository repo) => _repo = repo;

    public async Task<IEnumerable<Grade>> GetByEnrollmentIdAsync(int enrollmentId) => await _repo.GetByEnrollmentIdAsync(enrollmentId);

    public async Task<Grade> CreateAsync(Grade grade)
    {
        await _repo.AddAsync(grade);
        await _repo.SaveAsync();
        return grade;
    }

    public async Task UpdateAsync(Grade grade)
    {
        await _repo.UpdateAsync(grade);
        await _repo.SaveAsync();
    }
}
