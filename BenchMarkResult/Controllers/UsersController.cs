using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BenchMarkResult.Models.MultipleDbContext;

namespace BenchMarkResult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersDbContext _ucontext;
        public UsersController(UsersDbContext context)
        {
            _ucontext = context;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<UserModel>> GetUsers()
        {
            return _ucontext.Users.ToList();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<RoleModel>> GetRoles()
        {
            return _ucontext.Roles.ToList();
        }
    }
}