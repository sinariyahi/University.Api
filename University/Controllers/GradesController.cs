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
    [Route("api/students/{studentId}/grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly IMapper _mapper;
        public GradesController(IStudentGradeRepository studentGradeRepository, IMapper mapper)
        {
            _studentGradeRepository = studentGradeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetGradesAsync(Guid studentId)
        {
            if (!await _studentGradeRepository.StudentExists(studentId))
            {
                return NotFound();
            }

            var gradeEntity = await _studentGradeRepository.GetGradesAsync(studentId);
            return Ok(_mapper.Map<IEnumerable<GradeDto>>(gradeEntity));
        }
        [HttpGet("{gradeId}", Name = "GetGradeForStudent")]
        public async Task<IActionResult> GetGradeAsync(Guid studentId, Guid gradeId)
        {
            if (!await _studentGradeRepository.StudentExists(studentId))
            {
                return NotFound();
            }
            var gradeForStudent = await _studentGradeRepository.GetGradeAsync(studentId, gradeId);
            if (gradeForStudent == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GradeDto>(gradeForStudent));
        }
        [HttpPost]
        public async Task<IActionResult> CreateGrade(
           Guid studentId, GradeForCreationDto grade)
        {
            if (!await _studentGradeRepository.StudentExists(studentId))
            {
                return NotFound();
            }

            var gradeEntity = _mapper.Map<Grade>(grade);
            _studentGradeRepository.CreateGrade(studentId, gradeEntity);
            await _studentGradeRepository.SaveChangesAsync();

            var gradeToReturn = _mapper.Map<GradeDto>(gradeEntity);
            return CreatedAtRoute("GetStudent",
                new { studentId = studentId, gradeId = gradeToReturn.GradeId },
                gradeToReturn);
        }
        [HttpDelete("{gradeId}")]
        public async Task<IActionResult> DeleteGrade(Guid studentId, Guid gradeId)
        {
            if (!await _studentGradeRepository.StudentExists(studentId))
            {
                return NotFound();
            }
            var gradeForStudent = await _studentGradeRepository.GetGradeAsync(studentId, gradeId);
            if (gradeForStudent == null)
            {
                return NotFound();
            }
            _studentGradeRepository.DeleteGrade(gradeForStudent);
            await _studentGradeRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
