using Microsoft.EntityFrameworkCore;
using StudentOS.Api.Data;
using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context) { }

    public async Task<Student?> GetByUserIdAsync(string userId)
    {
        return await _context.Students
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.UserId == userId);
    }
}
