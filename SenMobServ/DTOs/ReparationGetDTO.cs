using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.DTOs
{
    public class ReparationGetDTO
    {
        public string Description { get; set; }
        public double Price { get; set; }

        public static ReparationGetDTO FromReparation(Reparation reparation)
        {
            return new ReparationGetDTO
            {
                Description = reparation.Description,
                Price = reparation.Price
            };
        }
    }
}
