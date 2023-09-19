namespace UniversityAPI.Models.ViewModel
{
    public class StudentViewModel
    {
        public uint IdStudent { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
        public string? Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Gender { get; set; } = null!;
        public int? IdCourse { get; set; }
        public string? Email { get; set; } = null!;
        public string? Phone { get; set; } = null!;
    }
}
