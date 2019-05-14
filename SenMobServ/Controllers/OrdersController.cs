using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenMobServ.Models;
using SenMobServ.Services;

namespace SenMobServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        
        private IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return orderService.GetAll();
        }

        // GET: api/Order/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = orderService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }


        // POST: api/Order
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            orderService.Create(order);
        }



        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            var result = orderService.Upsert(id, order);
            return Ok(result);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = orderService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}