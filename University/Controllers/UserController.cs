using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Entities;
using University.Infrastructure.Permissions;
using University.Models;
using University.Services;

namespace University.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public User Login([FromBody] UserDto user)
        {
            var User = _userService.Authenticate(user.Username, user.Password);

            return User;
        }

        [PermissionAuthorize(Permissions.User.GetAll)]
        [HttpGet("all")]
        public IEnumerable<User> GetAllUser()
        {
            return _userService.GetAll();
        }

        [PermissionAuthorize(Permissions.User.CheckUser)]
        [HttpGet("checkUser")]
        public string CheckUser()
        {
            return "You have access";
        }
    }
}
