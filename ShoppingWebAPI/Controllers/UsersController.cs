using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebAPI.Connector;
using ShoppingWebAPI.Models;

namespace ShoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private Conn _context;
        public UsersController(Conn context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            _context = HttpContext.RequestServices.GetService(typeof(Conn)) as Conn;
            return _context.GetAllUsers();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]User user)
        {
            _context = HttpContext.RequestServices.GetService(typeof(Conn)) as Conn;
            await user.Add();
            return new OkObjectResult(user);

        }
    }
}