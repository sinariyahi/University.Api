using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Entities;

namespace University.DbContexts
{
    public class StudentGradeContext : DbContext
    {
        public StudentGradeContext(DbContextOptions<StudentGradeContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
            .HasOne(s => s.Student)
            .WithMany(g => g.Grades)
            .HasForeignKey(s => s.StudentId);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
