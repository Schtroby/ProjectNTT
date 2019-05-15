using Microsoft.EntityFrameworkCore;
using SenMobServ.DTOs;
using SenMobServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Services
{
    public interface IReparationService
    {

        IEnumerable<ReparationGetDTO> GetAll();

        Reparation GetById(int id);

        Reparation Create(Reparation reparation);

        Reparation Upsert(int id, Reparation reparation);

        Reparation Delete(int id);

    }

    public class ReparationService : IReparationService
    {
        private EntitiesDbContext context;

        public ReparationService(EntitiesDbContext context)
        {
            this.context = context;
        }


        public Reparation Create(Reparation reparation)
        {
            context.Reparations.Add(reparation);
            context.SaveChanges();
            return reparation;

        }

        public Reparation Delete(int id)
        {
            var existing = context.Reparations.FirstOrDefault(reparation => reparation.ReparationId == id);
            if (existing == null)
            {
                return null;
            }
            context.Reparations.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public IEnumerable<ReparationGetDTO> GetAll()
        {
            IQueryable<Reparation> result = context.Reparations;
            return result.Select(r => ReparationGetDTO.FromReparation(r));
        }

        public Reparation GetById(int id)
        {
            return context.Reparations.FirstOrDefault(r => r.ReparationId == id);
        }

        public Reparation Upsert(int id, Reparation reparation)
        {
            var existing = context.Reparations.AsNoTracking().FirstOrDefault(r => r.ReparationId == id);
            if (existing == null)
            {
                context.Reparations.Add(reparation);
                context.SaveChanges();
                return reparation;

            }

            reparation.ReparationId = id;
            context.Reparations.Update(reparation);
            context.SaveChanges();
            return reparation;
        }
    }
}
