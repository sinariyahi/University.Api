using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DbContexts;
using University.Entities;

namespace University.Services
{
    public class StudentGradeRepository : IStudentGradeRepository
    {
        private readonly StudentGradeContext _context;
        public StudentGradeRepository(StudentGradeContext context)
        {
            _context = context;
        }

        public void CreateGrade(Guid studentId, Grade grade)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }
            grade.StudentId = studentId;
            _context.Grades.Add(grade);
        }
        public void CreateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            student.StudentId = Guid.NewGuid();
            foreach (var grade in student.Grades)
            {
                grade.GradeId = Guid.NewGuid();
            }

            _context.Students.Add(student);
        }

        public void DeleteGrade(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }
            _context.Grades.Remove(grade);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Students.Remove(student);
        }

        public async Task<Grade> GetGradeAsync(Guid studentId, Guid gradeId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            if (gradeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(gradeId));
            }
            return await _context.Grades
                .Where(c => c.StudentId == studentId && c.GradeId == gradeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return await _context.Grades.Where(c => c.StudentId == studentId)
                        .OrderBy(c => c.GradeName).ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return await _context.Students.FirstOrDefaultAsync(a => a.StudentId == studentId);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync<Student>();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> StudentExists(Guid studentId)
        {

            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return await _context.Students.AnyAsync(s => s.StudentId == studentId);
        }

        public void UpdateGrade(Grade grade)
        {
            throw new ArgumentNullException(nameof(grade));
        }

        public void UpdateStudent(Student student)
        {
            throw new ArgumentNullException(nameof(student));
        }
    }
}


