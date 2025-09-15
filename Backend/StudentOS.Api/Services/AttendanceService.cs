using StudentOS.Api.Models;
using StudentOS.Api.Repositories;

namespace StudentOS.Api.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repo;
    public AttendanceService(IAttendanceRepository repo) => _repo = repo;

    public async Task<IEnumerable<Attendance>> GetByEnrollmentIdAsync(int enrollmentId) => await _repo.GetByEnrollmentIdAsync(enrollmentId);

    public async Task<Attendance> CreateAsync(Attendance attendance)
    {
        await _repo.AddAsync(attendance);
        await _repo.SaveAsync();
        return attendance;
    }
}
