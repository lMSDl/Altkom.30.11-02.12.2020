using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentsService
    {
        int Create(Student student);
        Student Read(int id);
        IEnumerable<Student> Read();
        void Update(int id, Student student);
        void Delete(int id);
    }
}
