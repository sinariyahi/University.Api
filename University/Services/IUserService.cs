using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Entities;

namespace University.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
