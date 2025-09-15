using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<Teacher?> GetByUserIdAsync(string userId);
}
