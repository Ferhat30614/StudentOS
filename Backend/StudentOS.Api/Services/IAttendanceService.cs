using StudentOS.Api.Models;

namespace StudentOS.Api.Services;

public interface IAttendanceService
{
    Task<IEnumerable<Attendance>> GetByEnrollmentIdAsync(int enrollmentId);
    Task<Attendance> CreateAsync(Attendance attendance);
}
