using Microsoft.EntityFrameworkCore;
using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Services
{
    public interface IUserService
    {

        IEnumerable<User> GetAll();

        User GetById(int id);

        User Create(User user);

        User Upsert(int id, User user);

        User Delete(int id);

    }

    public class UserService : IUserService
    {
        private EntitiesDbContext context;

        public UserService(EntitiesDbContext context)
        {
            this.context = context;
        }


        public User Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var existing = context.Users.FirstOrDefault(user => user.UserId == id);
            if (existing == null)
            {
                return null;
            }
            context.Users.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User Upsert(int id, User user)
        {
            var existing = context.Users.AsNoTracking().FirstOrDefault(u => u.UserId == id);
            if (existing == null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user;

            }

            user.UserId = id;
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }
    }
}
