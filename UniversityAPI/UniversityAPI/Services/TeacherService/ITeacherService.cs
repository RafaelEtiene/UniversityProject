using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;

namespace UniversityAPI.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachers();

        Task<ActionResult<Teacher>> GetSingleTeacher(int id);

        Task InsertTeacher(Teacher request);

        Task UpdateTeacher(Teacher request);

        Task DeleteTeacher(int id);
    }
}
