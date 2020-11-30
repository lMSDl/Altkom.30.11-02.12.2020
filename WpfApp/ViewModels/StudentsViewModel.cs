using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class StudentsViewModel
    {
        public ICollection<Student> Students { get; }
        public StudentsViewModel()
        {
            Students = new List<Student>()
            {
                new Student() { FirstName = "Ewa", LastName = "Ewowska", IndexNumber = 512312},
                new Student() { FirstName = "Roman", LastName = "Romanowski", IndexNumber = 827123 },
                new Student() { FirstName = "Tadeusz", LastName = "Tadeuszowski", IndexNumber = 992712 },
            };
        }
    }
}
