using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using UniversityAPI.Data;

namespace UniversityAPI.Services.ExportExcelService
{
    public class ExportExcelService : IExportExcelService
    {
        private readonly UniversityContext _context;

        public ExportExcelService(UniversityContext context)
        {
            _context = context;
        }
        public async Task<MemoryStream> ExportStudentsDataToExcel()
        {
            try
            {
                var students = await _context.Students.ToListAsync();

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var excel = new ExcelPackage())
                {
                    var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

                    workSheet.TabColor = System.Drawing.Color.Black;
                    workSheet.DefaultRowHeight = 12;

                    workSheet.Row(1).Height = 20;
                    workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(1).Style.Font.Bold = true;

                    workSheet.Cells[1, 1].Value = "IdStudent";
                    workSheet.Cells[1, 2].Value = "Registration Date";
                    workSheet.Cells[1, 3].Value = "Name";
                    workSheet.Cells[1, 4].Value = "Age";
                    workSheet.Cells[1, 5].Value = "Gender";
                    workSheet.Cells[1, 6].Value = "IdCourse";
                    workSheet.Cells[1, 7].Value = "Email";
                    workSheet.Cells[1, 8].Value = "Phone";

                    var studentIndex = 2;

                    foreach (var student in students)
                    {
                        workSheet.Cells[studentIndex, 1].Value = student.IdStudent;
                        workSheet.Cells[studentIndex, 2].Value = student.RegistrationDate;
                        workSheet.Cells[studentIndex, 3].Value = student.Name;
                        workSheet.Cells[studentIndex, 4].Value = student.Age;
                        workSheet.Cells[studentIndex, 5].Value = student.Gender;
                        workSheet.Cells[studentIndex, 6].Value = student.IdCourse;
                        workSheet.Cells[studentIndex, 7].Value = student.Email;
                        workSheet.Cells[studentIndex, 8].Value = student.Phone;

                        studentIndex++;
                    }

                    workSheet.Column(1).AutoFit();
                    workSheet.Column(2).AutoFit();
                    workSheet.Column(3).AutoFit();
                    workSheet.Column(4).AutoFit();
                    workSheet.Column(5).AutoFit();
                    workSheet.Column(6).AutoFit();
                    workSheet.Column(7).AutoFit();
                    workSheet.Column(8).AutoFit();

                    var stream = new MemoryStream();

                    excel.SaveAs(stream);

                    return stream;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
