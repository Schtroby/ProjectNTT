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
    public class ReparationsController : ControllerBase
    {
        private IReparationService reparationService;
        public ReparationsController(IReparationService reparationService)
        {
            this.reparationService = reparationService;
        }
        // GET: api/Reparation
        [HttpGet]
        public IEnumerable<ReparationGetDTO> Get()
        {
            return reparationService.GetAll();
        }

        // GET: api/Reparation/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = reparationService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }


        // POST: api/Reparation
        [HttpPost]
        public void Post([FromBody] Reparation reparation)
        {
            reparationService.Create(reparation);
        }



        // PUT: api/Reparation/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reparation reparation)
        {
            var result = reparationService.Upsert(id, reparation);
            return Ok(result);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = reparationService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}