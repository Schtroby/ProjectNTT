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
    public class PhonesController : ControllerBase
    {
        private IPhoneService phoneService;
        public PhonesController(IPhoneService phoneService)
        {
            this.phoneService = phoneService;
        }
        // GET: api/Phone
        [HttpGet]
        public IEnumerable<PhoneGetDTO> Get()
        {
            return phoneService.GetAll();
        }

        // GET: api/Phone/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = phoneService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }


        // POST: api/Phone
        [HttpPost]
        public void Post([FromBody] Phone phone)
        {
            phoneService.Create(phone);
        }



        // PUT: api/Phone/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Phone phone)
        {
            var result = phoneService.Upsert(id, phone);
            return Ok(result);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = phoneService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}