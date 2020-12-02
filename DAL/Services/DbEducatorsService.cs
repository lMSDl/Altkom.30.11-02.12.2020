using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DbEducatorsService : DbCrudService<Educator>, IEducatorsService
    {
        public IEnumerable<Educator> ReadBySpecialization(string specialization)
        {
            using (var context = new Context())
            {
                //var item = context.Set<Educator>().Select(x => new { myName1 = x.LastName, myName2 = x.FirstName }).First();

                return context.Database.SqlQuery<Educator>("SELECT * FROM Educators WHERE Specialization = @spec", new SqlParameter("@spec", specialization)).ToList();
                //return context.Set<Educator>().SqlQuery("SELECT * FROM Educators WHERE Specialization = @spec", new SqlParameter("@spec", specialization)).ToList();
            }
        }
    }
}
