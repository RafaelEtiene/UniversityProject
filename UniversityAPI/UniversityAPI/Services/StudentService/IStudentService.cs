using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;

namespace UniversityAPI.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();

        Task<Student> GetSingleStudent(int id);

        Task InsertStudent(Student request);

        Task UpdateStudent(Student request);

        Task DeleteStudent(int id);
    }
}
