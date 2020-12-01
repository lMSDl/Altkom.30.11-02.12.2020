using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DbEducatorsService : IEducatorsService
    {
        public int Create(Educator educator)
        {
            using (var context = new Context())
            {
                educator = context.Set<Educator>().Add(educator);
                context.SaveChanges();
                //context.Dispose();
            }
            return educator.Id;
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var educator = context.Set<Educator>().Find(id);
                context.Set<Educator>().Remove(educator);
                context.SaveChanges();
            }
        }

        public Educator Read(int id)
        {
            using (var context = new Context())
            {
                return context.Set<Educator>().Find(id);
            }
        }

        public IEnumerable<Educator> Read()
        {
            using (var context = new Context())
            {
                return context.Set<Educator>().ToList();
            }
        }

        public void Update(int id, Educator educator)
        {
            educator.Id = id;
            using (var context = new Context())
            {
                context.Set<Educator>().Attach(educator);
                context.Entry(educator).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
