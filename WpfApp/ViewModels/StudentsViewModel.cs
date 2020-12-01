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
        public override ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Student()), obj => true);
        
        protected override Window CreateAddEditDialog(Person clone)
        {
            return new StudentDialog(clone);
        }

        protected override void Add(Person clone)
        {
        }

        protected override void Refresh()
        {
        }

        protected override void Update(int id, Person clone)
        {
        }

        protected override void Delete(int id)
        {
        }
    }
}
