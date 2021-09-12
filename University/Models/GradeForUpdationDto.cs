using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class GradeForUpdationDto
    {
        public Guid GradeId { get; set; }
        public string GradeName { get; set; }
        public string FieldofStudy { get; set; }

    }
}
