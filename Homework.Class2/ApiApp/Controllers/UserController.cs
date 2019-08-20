using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> users = new List<User>()
        {
            new User("Martin", "Petrovski", 16),
            new User("Dario", "Kostov", 25),
            new User("Petar", "Donevski", 25),
            new User("Goran", "Todorovski", 25),
            new User("Dragana", "Siskovska", 25)

        };

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                if (users[id - 1].Age < 18)
                {
                    users[id - 1].isUnderage = true;
                    return users[id - 1];
                }
                return users[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Ok($"Error {ex.Message}");
            }


        }
    }
}