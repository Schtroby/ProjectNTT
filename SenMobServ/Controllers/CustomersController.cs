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
    public class CustomersController : ControllerBase
    {

        private EntitiesDbContext context;
        public CustomersController(EntitiesDbContext context)
        {
            this.context = context;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return context.Customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Customers.FirstOrDefault(custromer => custromer.CustomerId == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }



        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            var existing = context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == id);
            if (existing == null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return Ok(customer);

            }

            customer.CustomerId = id;
            context.Customers.Update(customer);
            context.SaveChanges();
            return Ok(customer);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Customers.FirstOrDefault(customer => customer.CustomerId == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Customers.Remove(existing);
            context.SaveChanges();
            return Ok();
        }

    }
}