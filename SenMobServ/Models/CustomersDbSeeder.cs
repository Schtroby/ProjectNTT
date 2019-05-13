using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Models
{
    public class CustomersDbSeeder
    {
        public static void Initialize(EntitiesDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any movies.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            context.Customers.AddRange(
                new Customer
                {
                    Name = "Popa Jasmin",
                    PhoneNumber = "0725777777",
                    Email = "pj@gmail.com"
                    
                },
                new Customer
                {
                    Name = "Ardelean Roxana",
                    PhoneNumber = "0720777777",
                    Email = "ar@gmail.com"
                }
            );
            context.SaveChanges();
        }
    }
}
