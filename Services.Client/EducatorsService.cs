using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class EducatorsService : PeopleService<Educator>, IEducatorsService
    {
        public EducatorsService() : base("Educators")
        {
        }

        public IEnumerable<Educator> ReadBySpecialization(string specialization)
        {
            throw new NotImplementedException();
        }
    }
}
