using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Entities
{
    public class Grade
    {
        public Guid GradeId { get; set; }
        public string GradeName { get; set; }
        public string FieldofStudy { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }


    }
}
