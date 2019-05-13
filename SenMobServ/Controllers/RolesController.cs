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
    public class RolesController : ControllerBase
    {

        private EntitiesDbContext context;
        public RolesController(EntitiesDbContext context)
        {
            this.context = context;
        }
        // GET: api/Role
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return context.Roles;
        }

        // GET: api/Role/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existing = context.Roles.FirstOrDefault(role => role.RoleId == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        // POST: api/Role
        [HttpPost]
        public void Post([FromBody] Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
        }



        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role role)
        {
            var existing = context.Roles.AsNoTracking().FirstOrDefault(r => r.RoleId == id);
            if (existing == null)
            {
                context.Roles.Add(role);
                context.SaveChanges();
                return Ok(role);

            }

            role.RoleId = id;
            context.Roles.Update(role);
            context.SaveChanges();
            return Ok(role);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Roles.FirstOrDefault(role => role.RoleId == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Roles.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}