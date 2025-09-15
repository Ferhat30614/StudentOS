using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public interface IAttendanceRepository : IGenericRepository<Attendance>
{
    Task<IEnumerable<Attendance>> GetByEnrollmentIdAsync(int enrollmentId);
}
