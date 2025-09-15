using StudentOS.Api.Models;
using StudentOS.Api.Repositories;

namespace StudentOS.Api.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Student>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Student?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

    public async Task<Student?> GetByUserIdAsync(string userId) => await _repo.GetByUserIdAsync(userId);

    public async Task<Student> CreateAsync(Student student)
    {
        await _repo.AddAsync(student);
        await _repo.SaveAsync();
        return student;
    }

    public async Task UpdateAsync(Student student)
    {
        await _repo.UpdateAsync(student);
        await _repo.SaveAsync();
    }

    public async Task DeleteAsync(Student student)
    {
        await _repo.DeleteAsync(student);
        await _repo.SaveAsync();
    }
}
