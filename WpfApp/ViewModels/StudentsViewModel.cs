using DAL.Services;
using Models;
using Services.Interfaces;
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
    public class StudentsViewModel : PeopleViewModel<Student, IStudentsService>
    {
        public override ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Student()), obj => true);

        protected override IStudentsService Service { get; } = new DbStudentsService();

        protected override Window CreateAddEditDialog(Student clone)
        {
            return new StudentDialog(clone);
        }
    }
}
