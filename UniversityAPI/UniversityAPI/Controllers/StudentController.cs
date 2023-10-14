using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using UniversityAPI.Models;
using UniversityAPI.Models.ViewModel;
using UniversityAPI.Services.ExportExcelService;
using UniversityAPI.Services.StudentService;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IExportExcelService _exportExcelService;
        public StudentController(IStudentService studentService, IExportExcelService exportExcelService)
        {
            _studentService = studentService;
            _exportExcelService = exportExcelService;
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

        [HttpGet]
        [Route("ExportStudentsDataToExcel")]
        public async Task<IActionResult> ExportStudentsDataToExcel()
        {
            try
            {
                var excelStream = await _exportExcelService.ExportStudentsDataToExcel();

                var contentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "example.xlsx"
                };
                Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
                Response.Headers.Add("X-Content-Type-Options", "nosniff");
                Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

                excelStream.Seek(0, SeekOrigin.Begin);

                return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "example.xlsx");

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
