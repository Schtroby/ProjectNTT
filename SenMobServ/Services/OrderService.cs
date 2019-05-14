using Microsoft.EntityFrameworkCore;
using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Services
{
    public interface IOrderService
    {

        IEnumerable<Order> GetAll();

        Order GetById(int id);

        Order Create(Order order);

        Order Upsert(int id, Order order);

        Order Delete(int id);

    }

    public class OrderService : IOrderService
    {
        private EntitiesDbContext context;


        public OrderService(EntitiesDbContext context)
        {
            this.context = context;
        }


        public Order Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }


        public Order Delete(int id)
        {
            var existing = context.Orders.FirstOrDefault(order => order.OrderId == id);
            if (existing == null)
            {
                return null;
            }
            context.Orders.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders;
        }

        public Order GetById(int id)
        {
            return context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public Order Upsert(int id, Order order)
        {
            var existing = context.Orders.AsNoTracking().FirstOrDefault(o => o.OrderId == id);
            if (existing == null)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return order;

            }

            order.OrderId = id;
            context.Orders.Update(order);
            context.SaveChanges();
            return order;

        }
    }
}
