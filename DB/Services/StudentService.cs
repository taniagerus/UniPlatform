using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB.Entities;
public class StudentService : IStudentService
{
    private readonly IGenericRepository<Student> _studentRepository;

    public StudentService(IGenericRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task<Student> GetStudentByIdAsync(string id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    public async Task AddStudentAsync(Student student)
    {
        await _studentRepository.AddAsync(student);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await _studentRepository.UpdateAsync(student);
    }

    public async Task DeleteStudentAsync(string id)
    {
        await _studentRepository.DeleteAsync(id);
    }
}
