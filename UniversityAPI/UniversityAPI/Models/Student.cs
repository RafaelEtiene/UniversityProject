using System;
using System.Collections.Generic;

namespace UniversityAPI.Models
{
    public partial class Student
    {
        public uint IdStudent { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public int IdCourse { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
