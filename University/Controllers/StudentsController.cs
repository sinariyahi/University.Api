using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Entities;
using University.Models;
using University.Services;

namespace University.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly IMapper _mapper;
        public StudentsController(IStudentGradeRepository studentGradeRepository, IMapper mapper)
        {
            _studentGradeRepository = studentGradeRepository;
            _mapper = mapper;
        }
        [HttpGet("{studentId}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudentAsync(Guid studentId)
        {
            var studentEntity = await _studentGradeRepository.GetStudentAsync(studentId);
            if (studentEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StudentDto>(studentEntity));
        }
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            var studentEntity = await _studentGradeRepository.GetStudentAsync(studentId);
            if (studentEntity == null)
            {
                return NotFound();
            }
            _studentGradeRepository.DeleteStudent(studentEntity);
            await _studentGradeRepository.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentForCreationDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            _studentGradeRepository.CreateStudent(studentEntity);
            await _studentGradeRepository.SaveChangesAsync();

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return CreatedAtRoute("GetStudent",
                new { studentId = studentToReturn.StudentId },
                studentToReturn);
        }
    }
}
