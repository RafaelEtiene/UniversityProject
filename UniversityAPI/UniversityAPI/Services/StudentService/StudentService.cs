using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly UniversityContext _context;

        public StudentService(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("No students were found. " + e.Message);
            }
        }

        public async Task<Student> GetSingleStudent(int id)
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

        public async Task InsertStudent(Student request)
        {
            try
            {
                _context.Students.Add(request);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred when inserting student. " + e.Message);
            }
        }

        public async Task UpdateStudent(Student request)
        {
            try
            {
                var student = await _context.Students.FindAsync(request.IdStudent);

                if (student is null)
                    throw new Exception("No students were found");

                student.Name = request.Name;
                student.Phone = request.Phone;
                student.Email = request.Email;
                student.Gender = request.Gender;
                student.Age = request.Age;
                student.IdCourse = request.IdCourse;

                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("An error has ocurred when updating student. " + e.Message);
            }
        }


        public async Task DeleteStudent(int id)
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

    }
}
