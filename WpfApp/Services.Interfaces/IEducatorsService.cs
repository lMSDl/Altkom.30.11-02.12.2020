using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEducatorsService
    {
        int Create(Educator educator);
        Educator Read(int id);
        IEnumerable<Educator> Read();
        void Update(int id, Educator educator);
        void Delete(int id);
    }
}
