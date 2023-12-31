﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using UniversityAPI.Data;
using UniversityAPI.Models;
using UniversityAPI.Models.ViewModel;

namespace UniversityAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly UniversityContext _context;
        private readonly IMapper _mapper;

        public StudentService(UniversityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Student>> GetAllStudents(FilterStudentViewModel request)
        {
            try
            {
                if(request.InitialDate != null && request.FinalDate != null)
                {
                    if ((!string.IsNullOrEmpty(request.Email)) && (!string.IsNullOrEmpty(request.Name)))
                    {
                        return await _context.Students
                        .Where(s => (s.RegistrationDate >= request.InitialDate) && (s.RegistrationDate <= request.FinalDate) && (s.Email == request.Email) && (s.Name.Contains(request.Name)))
                        .ToListAsync();
                    }

                    if (!string.IsNullOrEmpty(request.Email))
                    {
                        return await _context.Students
                        .Where(s => (s.RegistrationDate >= request.InitialDate) && (s.RegistrationDate <= request.FinalDate) && (s.Email == request.Email))
                        .ToListAsync();
                    }

                    if (!string.IsNullOrEmpty(request.Name))
                    {
                        return await _context.Students
                        .Where(s => (s.RegistrationDate >= request.InitialDate) && (s.RegistrationDate <= request.FinalDate) && (s.Name.Contains(request.Name)))
                        .ToListAsync();
                    }

                    return await _context.Students
                        .Where(s => (s.RegistrationDate >= request.InitialDate) && (s.RegistrationDate <= request.FinalDate))
                        .ToListAsync();
                }

                if ((!string.IsNullOrEmpty(request.Email)) && (!string.IsNullOrEmpty(request.Name)))
                {
                    return await _context.Students
                    .Where(s => (s.Email == request.Email) && (s.Name.Contains(request.Name)))
                    .ToListAsync();
                }

                if (!string.IsNullOrEmpty(request.Email))
                {
                    return await _context.Students
                    .Where(s => s.Email == request.Email)
                    .ToListAsync();
                }

                if (!string.IsNullOrEmpty(request.Name))
                {
                    return await _context.Students
                    .Where(s => s.Name.Contains(request.Name))
                    .ToListAsync();
                }

                return await _context.Students
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("No students were found. " + e.Message);
            }
        }

        public async Task<Student> GetSingleStudent(uint id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student is null)
                    throw new Exception("The student not exist.");

                return student;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred when searching student. " + e.Message);
            }
        }

        public async Task InsertStudent(StudentViewModel request)
        {
            try
            {
                var student = _mapper.Map<StudentViewModel, Student>(request);
                _context.Students.Add(student);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred when inserting student. " + e.Message);
            }
        }

        public async Task UpdateStudent(StudentViewModel request)
        {
            try
            {
                var studentRequest = _mapper.Map<StudentViewModel, Student>(request);

                var student = await _context.Students.FindAsync(studentRequest.IdStudent);

                if (student is null)
                    throw new Exception("No students were found");

                if(!string.IsNullOrEmpty(studentRequest.Name))
                    student.Name = studentRequest.Name;

                if (studentRequest.RegistrationDate != null)
                    student.RegistrationDate = studentRequest.RegistrationDate;

                if(!string.IsNullOrEmpty(studentRequest.Phone))
                    student.Phone = studentRequest.Phone;

                if(!string.IsNullOrEmpty(studentRequest.Email))
                    student.Email = studentRequest.Email;

                if(!string.IsNullOrEmpty(studentRequest.Gender))
                    student.Gender = studentRequest.Gender;
                
                if(studentRequest.Age != 0)
                    student.Age = studentRequest.Age;

                if(studentRequest.IdCourse != 0)
                    student.IdCourse = studentRequest.IdCourse;

                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("An error has ocurred when updating student. " + e.Message);
            }
        }


        public async Task DeleteStudent(uint id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student is null)
                    throw new Exception("No students were found");

                _context.Students.Remove(student);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error has ocurred when removing student. " + e.Message);
            }
        }

        public async Task<StudentsAnalyticsInfo> GetStudentsAnalyticsInfo()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                var courses = await _context.Courses.ToListAsync();

                var popularCourse = (
                    from c in courses
                    join s in students on c.IdCourse equals s.IdCourse
                    group s by s.IdCourse into grouped
                    orderby grouped.Count() descending
                    select grouped.Key)
                    .FirstOrDefault();

                var course = GetCourseByObject(popularCourse);


                return new StudentsAnalyticsInfo
                {
                    StudentsCount = students.Count(),
                    LastRegisteredStudents = students.Where(s => s.RegistrationDate.Month == DateTime.Now.Month).Count(),
                    PopularCourse = course.Result.Name
            };
            }
            catch
            {
                throw;
            }
        }

        private async Task<Course> GetCourseByObject(int idCourse)
        {
            var result = await _context.Courses.Where(c => c.IdCourse == idCourse).SingleAsync();

            if (!(result is null))
                return result;
            else
            {
                throw new Exception("This course don't exists");
            }
        }
    }
}
