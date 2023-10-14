using Microsoft.AspNetCore.Mvc;

namespace UniversityAPI.Services.ExportExcelService
{
    public interface IExportExcelService
    {
        Task<MemoryStream> ExportStudentsDataToExcel();

    }
}
