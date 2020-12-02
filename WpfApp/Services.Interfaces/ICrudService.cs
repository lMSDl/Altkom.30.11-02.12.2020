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

        Task<int> CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        Task<IEnumerable<T>> ReadAsync();
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
