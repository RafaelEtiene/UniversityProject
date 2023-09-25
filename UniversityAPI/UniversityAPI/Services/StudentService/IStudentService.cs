﻿using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Models.ViewModel;

namespace UniversityAPI.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents(FilterStudentViewModel request);

        Task<Student> GetSingleStudent(int id);

        Task InsertStudent(StudentViewModel request);

        Task UpdateStudent(StudentViewModel request);

        Task DeleteStudent(int id);
    }
}
