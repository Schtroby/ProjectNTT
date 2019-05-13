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
    public class PhonesController : ControllerBase
    {
        private EntitiesDbContext context;
        public PhonesController(EntitiesDbContext context)
        {
            this.context = context;
        }
        // GET: api/Phone
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return context.Phones;
        }

        // GET: api/Phone/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existing = context.Phones.FirstOrDefault(phone => phone.PhoneId == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        // POST: api/Phone
        [HttpPost]
        public void Post([FromBody] Phone phone)
        {
            context.Phones.Add(phone);
            context.SaveChanges();
        }



        // PUT: api/Phone/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Phone phone)
        {
            var existing = context.Phones.AsNoTracking().FirstOrDefault(p => p.PhoneId == id);
            if (existing == null)
            {
                context.Phones.Add(phone);
                context.SaveChanges();
                return Ok(phone);

            }

            phone.PhoneId = id;
            context.Phones.Update(phone);
            context.SaveChanges();
            return Ok(phone);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Phones.FirstOrDefault(phone => phone.PhoneId == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Phones.Remove(existing);
            context.SaveChanges();
            return Ok();
        }

    }
}