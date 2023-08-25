using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly UniversityContext _context;

        public CourseService(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            try
            {
                return await _context.Courses.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("No course were found. " + e.Message);
            }
        }

        public async Task<Course> GetSingleCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);

                if (course is null)
                    throw new Exception("The course not exist.");

                return course;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred when searching course. " + e.Message);
            }
        }

        public async Task InsertCourse(Course request)
        {
            try
            {
                _context.Courses.Add(request);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred when inserting course. " + e.Message);
            }
        }

        public async Task UpdateCourse(Course request)
        {
            try
            {
                var course = await _context.Courses.FindAsync(request.IdCourse);

                if (course is null)
                    throw new Exception("No course were found");

                _context.Courses.Update(request);

                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("An error has ocurred when updating course. " + e.Message);
            }
        }


        public async Task DeleteCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);

                if (course is null)
                    throw new Exception("No course were found");

                _context.Courses.Remove(course);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error has ocurred when removing course. " + e.Message);
            }
        }

    }
}
