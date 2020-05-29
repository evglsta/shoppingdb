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
    public class ShoppingController : ControllerBase
    {
        private Conn _context;

        public ShoppingController(Conn context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shopping>> GetShoppings()
        {
            _context = HttpContext.RequestServices.GetService(typeof(Conn)) as Conn;
            return _context.GetAllShopping();
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<Shopping>> GetShopping(string id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(Conn)) as Conn;
            return _context.GetShopping(id);
        }
    }
}