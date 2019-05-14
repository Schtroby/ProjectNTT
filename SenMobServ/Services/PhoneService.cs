using Microsoft.EntityFrameworkCore;
using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Services
{
    public interface IPhoneService
    {

        IEnumerable<Phone> GetAll();

        Phone GetById(int id);

        Phone Create(Phone phone);

        Phone Upsert(int id, Phone phone);

        Phone Delete(int id);

    }
    public class PhoneService : IPhoneService
    {
        private EntitiesDbContext context;

        public PhoneService(EntitiesDbContext context)
        {
            this.context = context;
        }

        public Phone Create(Phone phone)
        {
            context.Phones.Add(phone);
            context.SaveChanges();
            return phone;
        }

        public Phone Delete(int id)
        {
            var existing = context.Phones.FirstOrDefault(phone => phone.PhoneId == id);
            if (existing == null)
            {
                return null;
            }
            context.Phones.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public IEnumerable<Phone> GetAll()
        {
            return context.Phones;
        }

        public Phone GetById(int id)
        {
            return context.Phones.FirstOrDefault(p => p.PhoneId == id);

        }

        public Phone Upsert(int id, Phone phone)
        {
            var existing = context.Phones.AsNoTracking().FirstOrDefault(p => p.PhoneId == id);
            if (existing == null)
            {
                context.Phones.Add(phone);
                context.SaveChanges();
                return phone;

            }

            phone.PhoneId = id;
            context.Phones.Update(phone);
            context.SaveChanges();
            return phone;

        }
    }
}
