using StudentOS.Api.Models;

namespace StudentOS.Api.Services;

public interface IGradeService
{
    Task<IEnumerable<Grade>> GetByEnrollmentIdAsync(int enrollmentId);
    Task<Grade> CreateAsync(Grade grade);
    Task UpdateAsync(Grade grade);
}
