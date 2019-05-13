using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenMobServ.Models;

namespace SenMobServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private EntitiesDbContext context;
        public UsersController(EntitiesDbContext context)
        {
            this.context = context;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.Users;
        }

        // GET: api/User/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existing = context.Users.FirstOrDefault(user => user.UserId == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }



        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var existing = context.Users.AsNoTracking().FirstOrDefault(u => u.UserId == id);
            if (existing == null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(user);

            }

            user.UserId = id;
            context.Users.Update(user);
            context.SaveChanges();
            return Ok(user);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Users.FirstOrDefault(user => user.UserId == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Users.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}