using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Models.ViewModel;
using UniversityAPI.Services.StudentService;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents([FromQuery]FilterStudentViewModel request)
        {
            try
            {
                var result = await _studentService.GetAllStudents(request);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetSingleStudent/{id}")]
        public async Task<IActionResult> GetSingleStudent(uint id)
        {
            try
            {
                var result = await _studentService.GetSingleStudent(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("InsertStudent")]
        public async Task<IActionResult> InsertStudent([FromBody]StudentViewModel request)
        {
            try
            {
                await _studentService.InsertStudent(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentViewModel request)
        {
            try
            {
                await _studentService.UpdateStudent(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetStudentsAnalyticsInfo")]
        public async Task<IActionResult> GetStudentsAnalyticsInfo()
        {
            try
            {
                var result = await _studentService.GetStudentsAnalyticsInfo();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
