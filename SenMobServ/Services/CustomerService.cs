using Microsoft.EntityFrameworkCore;
using SenMobServ.DTOs;
using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Services
{
    public interface ICustomerService
    {

        IEnumerable<CustomerGetDTO> GetAll();

        Customer GetById(int id);

        Customer Create(Customer customer);

        Customer Upsert(int id, Customer customer);

        Customer Delete(int id);

    }

    public class CustomerService : ICustomerService
    {
        private EntitiesDbContext context;

        public CustomerService(EntitiesDbContext context)
        {
            this.context = context;
        }

        
        public Customer Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer Delete(int id)
        {
            var existing = context.Customers.FirstOrDefault(customer => customer.CustomerId == id);
            if (existing == null)
            {
                return null;
            }
            context.Customers.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public IEnumerable<CustomerGetDTO> GetAll()
        {
            IQueryable<Customer> result = context.Customers;

            //return result.Select(c => new CustomerGetDTO {
            //    Name = c.Name,
            //    PhoneNumber = c.PhoneNumber,
            //    Email = c.Email
            //}
            return result.Select(c => CustomerGetDTO.FromCustomer(c));
            
        }

        public Customer GetById(int id)
        {
            return context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer Upsert(int id, Customer customer)
        {
            var existing = context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == id);
            if (existing == null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return customer;

            }

            customer.CustomerId = id;
            context.Customers.Update(customer);
            context.SaveChanges();
            return customer;
        }
    }
}
 