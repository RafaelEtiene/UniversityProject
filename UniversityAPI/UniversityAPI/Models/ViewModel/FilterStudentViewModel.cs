namespace UniversityAPI.Models.ViewModel
{
    public class FilterStudentViewModel
    {
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
