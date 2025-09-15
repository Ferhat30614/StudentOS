using Microsoft.EntityFrameworkCore;
using StudentOS.Api.Data;
using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext context) : base(context) { }

    public async Task<Teacher?> GetByUserIdAsync(string userId)
    {
        return await _context.Teachers
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.UserId == userId);
    }
}
