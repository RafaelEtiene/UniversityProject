using UniversityAPI.Models;

namespace UniversityAPI.Services.CourseService
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();

        Task<Course> GetSingleCourse(int id);

        Task InsertCourse(Course request);

        Task UpdateCourse(Course request);

        Task DeleteCourse(int id);

        Task<double> GetPriceAverage();
    }
}
