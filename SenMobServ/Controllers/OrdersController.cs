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
    public class OrdersController : ControllerBase
    {
        private EntitiesDbContext context;
        public OrdersController(EntitiesDbContext context)
        {
            this.context = context;
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return context.Orders;
        }

        // GET: api/Order/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existing = context.Orders.FirstOrDefault(order => order.OrderId == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        // POST: api/Order
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }



        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            var existing = context.Orders.AsNoTracking().FirstOrDefault(o => o.OrderId == id);
            if (existing == null)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return Ok(order);

            }

            order.OrderId = id;
            context.Orders.Update(order);
            context.SaveChanges();
            return Ok(order);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Orders.FirstOrDefault(order => order.OrderId == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Orders.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}