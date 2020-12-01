using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DbCrudService<T> : ICrudService<T> where T : Entity
    {
        public int Create(T entity)
        {
            using (var context = new Context())
            {
                entity = context.Set<T>().Add(entity);
                context.SaveChanges();
                //context.Dispose();
            }
            return entity.Id;
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var entity = context.Set<T>().Find(id);
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public T Read(int id)
        {
            using (var context = new Context())
            {
                return context.Set<T>().Find(id);
            }
        }

        public IEnumerable<T> Read()
        {
            using (var context = new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Update(int id, T entity)
        {
            entity.Id = id;
            using (var context = new Context())
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
