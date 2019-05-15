using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.DTOs
{
    public class PhoneGetDTO
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public static PhoneGetDTO FromPhone (Phone phone)
        {
            return new PhoneGetDTO
            {
                Brand = phone.Brand,
                Model = phone.Model,
                SerialNumber = phone.SerialNumber
            };
        }
    }
}
