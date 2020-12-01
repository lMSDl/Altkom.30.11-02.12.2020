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
    public class EducatorsViewModel : PeopleViewModel
    {
        public EducatorsViewModel() : base(new List<Educator>()
            {
                new Educator() { FirstName = "Ewa", LastName = "Ewowska", Specialization = "Gotowanie" },
                new Educator() { FirstName = "Roman", LastName = "Romanowski", Specialization = "Budownictwo" },
                new Educator() { FirstName = "Tadeusz", LastName = "Tadeuszowski", Specialization = "IT" },
            })
        {
        }

        public override ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Educator()), obj => true);

        protected override Window CreateAddEditDialog(Person clone)
        {
            return new EducatorDialog(clone);
        }
    }
}
