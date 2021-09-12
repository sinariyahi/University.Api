using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

    }
}
