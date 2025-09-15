using StudentOS.Api.Models;

namespace StudentOS.Api.Repositories;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<Student?> GetByUserIdAsync(string userId);
}
