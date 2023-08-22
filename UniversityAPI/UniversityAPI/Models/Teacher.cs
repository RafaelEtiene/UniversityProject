using System;
using System.Collections.Generic;

namespace UniversityAPI.Models
{
    public partial class Teacher
    {
        public uint IdTeacher { get; set; }
        public string Name { get; set; } = null!;
        public string Age { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int IdCourse { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
