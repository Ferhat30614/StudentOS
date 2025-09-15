using Microsoft.EntityFrameworkCore;
using StudentOS.Api.Data;
using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Attendance>> GetByEnrollmentIdAsync(int enrollmentId) =>
        await _context.Attendances.Where(a => a.EnrollmentId == enrollmentId).ToListAsync();
}
