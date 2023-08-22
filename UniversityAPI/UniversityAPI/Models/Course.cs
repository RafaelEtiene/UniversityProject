using System;
using System.Collections.Generic;

namespace UniversityAPI.Models
{
    public partial class Course
    {
        public int IdCourse { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int IdTeacher { get; set; }
    }
}
