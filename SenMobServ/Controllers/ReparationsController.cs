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
    public class ReparationsController : ControllerBase
    {
        private EntitiesDbContext context;
        public ReparationsController(EntitiesDbContext context)
        {
            this.context = context;
        }
        // GET: api/Reparation
        [HttpGet]
        public IEnumerable<Reparation> Get()
        {
            return context.Reparations;
        }

        // GET: api/Reparation/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existing = context.Reparations.FirstOrDefault(reparation => reparation.ReparationId == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        // POST: api/Reparation
        [HttpPost]
        public void Post([FromBody] Reparation reparation)
        {
            context.Reparations.Add(reparation);
            context.SaveChanges();
        }



        // PUT: api/Reparation/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reparation reparation)
        {
            var existing = context.Reparations.AsNoTracking().FirstOrDefault(r => r.ReparationId == id);
            if (existing == null)
            {
                context.Reparations.Add(reparation);
                context.SaveChanges();
                return Ok(reparation);

            }

            reparation.ReparationId = id;
            context.Reparations.Update(reparation);
            context.SaveChanges();
            return Ok(reparation);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Reparations.FirstOrDefault(reparation => reparation.ReparationId == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Reparations.Remove(existing);
            context.SaveChanges();
            return Ok();
        }

    }
}