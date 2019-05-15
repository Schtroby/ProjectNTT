using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.DTOs
{
    public class CustomerGetDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public static CustomerGetDTO FromCustomer (Customer customer)
        {
            return new CustomerGetDTO
            {
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };
        }
    }
}
