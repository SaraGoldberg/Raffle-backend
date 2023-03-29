using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL _userBl;
        ILogger<UserController> _logger;
        public UserController(IUserBL userBL, ILogger<UserController> logger)
        {
            _userBl = userBL;
            _logger = logger;
        }
        
        // GET: api/<UserController>
        [HttpGet("{name}/{pswd}")]
        public async Task<ActionResult<User>> Get(string name, string pswd)
        {
            //throw new Exception("no :(\n"); //נסיון שימוש בלוגר לשגיאה
            User user = await _userBl.getUser(name, pswd);
            if (user == null)
                return NoContent();
            _logger.LogInformation("\nUSER NAME {0} PASSWORD {1} CONNECTED\n", name, pswd);
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] User value)
        {
            await _userBl.postUser(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await _userBl.putUser(id, userToUpdate);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}