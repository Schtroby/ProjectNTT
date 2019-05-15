using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenMobServ.DTOs;
using SenMobServ.Models;
using SenMobServ.Services;

namespace SenMobServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private ICustomerService customerService;
        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomerGetDTO> Get()
        {
            return customerService.GetAll();
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var found = customerService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }


        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            customerService.Create(customer);
        }



        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            var result = customerService.Upsert(id, customer);
            return Ok(result);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = customerService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}