using StudentOS.Api.Models;
using StudentOS.Api.Repositories;

namespace StudentOS.Api.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repo;

    public TeacherService(ITeacherRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Teacher?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

    public async Task<Teacher?> GetByUserIdAsync(string userId) => await _repo.GetByUserIdAsync(userId);

    public async Task<Teacher> CreateAsync(Teacher teacher)
    {
        await _repo.AddAsync(teacher);
        await _repo.SaveAsync();
        return teacher;
    }

    public async Task UpdateAsync(Teacher teacher)
    {
        await _repo.UpdateAsync(teacher);
        await _repo.SaveAsync();
    }

    public async Task DeleteAsync(Teacher teacher)
    {
        await _repo.DeleteAsync(teacher);
        await _repo.SaveAsync();
    }
}
