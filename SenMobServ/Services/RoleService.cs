using Microsoft.EntityFrameworkCore;
using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Services
{
    public interface IRoleService
    {

        IEnumerable<Role> GetAll();

        Role GetById(int id);

        Role Create(Role role);

        Role Upsert(int id, Role role);

        Role Delete(int id);

    }
    public class RoleService : IRoleService
    {
        private EntitiesDbContext context;

        public RoleService(EntitiesDbContext context)
        {
            this.context = context;
        }


        public Role Create(Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            return role;
        }

        public Role Delete(int id)
        {
            var existing = context.Roles.FirstOrDefault(role => role.RoleId == id);
            if (existing == null)
            {
                return null;
            }
            context.Roles.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Roles;
        }

        public Role GetById(int id)
        {
            return context.Roles.FirstOrDefault(r => r.RoleId == id);
        }

        public Role Upsert(int id, Role role)
        {
            var existing = context.Roles.AsNoTracking().FirstOrDefault(r => r.RoleId == id);
            if (existing == null)
            {
                context.Roles.Add(role);
                context.SaveChanges();
                return role;

            }

            role.RoleId = id;
            context.Roles.Update(role);
            context.SaveChanges();
            return role;
        }
    }
}
