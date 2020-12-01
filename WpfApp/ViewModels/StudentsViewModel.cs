using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class StudentsViewModel : PeopleViewModel
    {
        public StudentsViewModel() : base(new List<Student>()
            {
                new Student() { FirstName = "Ewa", LastName = "Ewowska", IndexNumber = 512312},
                new Student() { FirstName = "Roman", LastName = "Romanowski", IndexNumber = 827123 },
                new Student() { FirstName = "Tadeusz", LastName = "Tadeuszowski", IndexNumber = 992712 },
            })
        {
        }

        public override ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Student()), obj => true);

        protected override Window CreateAddEditDialog(Person clone)
        {
            return new StudentDialog(clone);
        }
    }
}
