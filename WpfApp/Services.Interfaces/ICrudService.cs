using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICrudService<T> where T : Entity
    {
        int Create(T entity);
        T Read(int id);
        IEnumerable<T> Read();
        void Update(int id, T entity);
        void Delete(int id);
    }
}
