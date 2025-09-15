using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public interface IGradeRepository : IGenericRepository<Grade>
{
    Task<IEnumerable<Grade>> GetByEnrollmentIdAsync(int enrollmentId);
}
