using Microsoft.EntityFrameworkCore;
using StudentOS.Api.Data;
using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public class GradeRepository : GenericRepository<Grade>, IGradeRepository
{
    public GradeRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Grade>> GetByEnrollmentIdAsync(int enrollmentId) =>
        await _context.Grades.Where(g => g.EnrollmentId == enrollmentId).ToListAsync();
}
