using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly UniversityContext _context;

        public TeacherService(UniversityContext context)
        {
            _context = context;
        }
        public async Task<List<Teacher>> GetAllTeachers()
        {
            try
            {
                return await _context.Teachers.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("No teachers were found. " + e.Message);
            }
        }

        public async Task<ActionResult<Teacher>> GetSingleTeacher(int id)
        {
            try
            {
                var teacher = await _context.Teachers.FindAsync(id);

                if (teacher is null)
                    throw new Exception("The teacher not exist.");

                return teacher;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred when searching teacher. " + e.Message);
            }
        }

        public async Task InsertTeacher(Teacher request)
        {
            try
            {
                _context.Teachers.Add(request);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred when inserting teacher. " + e.Message);
            }
        }

        public async Task UpdateTeacher(Teacher request)
        {
            try
            {
                var teacher = await _context.Teachers.FindAsync(request.IdTeacher);

                if (teacher is null)
                    throw new Exception("No teacher were found");

                _context.Teachers.Update(teacher);
            }
            catch(Exception e)
            {
                throw new Exception("An error occurred when upadating teacher" + e.Message);
            }
        }

        public async Task DeleteTeacher(int id)
        {
            try
            {
                var teacher = await _context.Teachers.FindAsync(id);

                if (teacher is null)
                    throw new Exception("No students were found");

                _context.Teachers.Remove(teacher);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error has ocurred when removing teacher. " + e.Message);
            }
        }
    }
}
