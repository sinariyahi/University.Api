using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public List<Grade> Grades { get; set; } = new List<Grade>();

    }
}
