using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            return;
        }

        [HttpGet]
        [Route("GetSingleStudent/{id}")]
        public async Task<ActionResult<Student>> GetSingleStudent(int id)
        {
            return;
        }

        [HttpPost]
        [Route("InsertStudent")]
        public async Task<IActionResult> InsertStudent(Student request)
        {
            return Ok(true);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(Student request)
        {
            return Ok(true);
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            return Ok();
        }

    }
}
