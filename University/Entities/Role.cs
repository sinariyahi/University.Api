using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Entities
{
    public class Role
    {
        public string Name { get; set; }
        public string[] Permissions { get; set; }
    }
}
