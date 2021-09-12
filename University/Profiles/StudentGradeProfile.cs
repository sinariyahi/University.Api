using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Entities;
using University.Models;

namespace University.Profiles
{
    public class StudentGradeProfile : Profile
    {
        public StudentGradeProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Grade, GradeDto>();
            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdationDto, Student>();
            CreateMap<GradeForCreationDto, Grade>();
            CreateMap<GradeForUpdationDto, Grade>();

        }
    }
}
