using AutoMapper;
using UniversityAPI.Models.ViewModel;

namespace UniversityAPI.Models.Mapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentViewModel, Student>();
        }
    }
}
