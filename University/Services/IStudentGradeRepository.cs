using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Entities;

namespace University.Services
{
    public interface IStudentGradeRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        Task<IEnumerable<Grade>> GetGradesAsync(Guid studentId);
        Task<Grade> GetGradeAsync(Guid studentId, Guid gradeId);
        void CreateGrade(Guid studentId, Grade grade);
        void UpdateGrade(Grade grade);
        void DeleteGrade(Grade grade);
        Task<bool> StudentExists(Guid studentId);
        Task<bool> SaveChangesAsync();



    }
}
