using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DbStudentsService : IStudentsService
    {
        public int Create(Student student)
        {
            using (var context = new Context())
            {
                student = context.Set<Student>().Add(student);
                context.SaveChanges();
                //context.Dispose();
            }
            return student.Id;
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var student = context.Set<Student>().Find(id);
                context.Set<Student>().Remove(student);
                context.SaveChanges();
            }
        }

        public Student Read(int id)
        {
            using (var context = new Context())
            {
                return context.Set<Student>().Find(id);
            }
        }

        public IEnumerable<Student> Read()
        {
            using (var context = new Context())
            {
                return context.Set<Student>().ToList();
            }
        }

        public void Update(int id, Student student)
        {
            student.Id = id;
            using (var context = new Context())
            {
                context.Set<Student>().Attach(student);
                context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
