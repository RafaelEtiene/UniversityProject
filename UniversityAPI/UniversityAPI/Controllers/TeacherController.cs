using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Services.CourseService;
using UniversityAPI.Services.TeacherService;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        [Route("GetAllTeachers")]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            try
            {
                var result = await _teacherService.GetAllTeachers();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetSingleTeacher/{id}")]
        public async Task<ActionResult<Teacher>> GetSingleTeacher(int id)
        {
            try
            {
                var result = await _teacherService.GetSingleTeacher(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("InsertTeacher")]
        public async Task<IActionResult> InsertTeacher(Teacher request)
        {
            try
            {
                await _teacherService.InsertTeacher(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher(Teacher request)
        {
            try
            {
                await _teacherService.UpdateTeacher(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            try
            {
                await _teacherService.DeleteTeacher(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
