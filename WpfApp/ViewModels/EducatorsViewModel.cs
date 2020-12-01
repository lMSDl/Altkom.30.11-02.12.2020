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
    public class EducatorsViewModel : PeopleViewModel<Educator>
    {

        public override ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Educator()), obj => true);

        protected override ICrudService<Educator> Service { get; } = new DbEducatorsService();

        protected override Window CreateAddEditDialog(Educator clone)
        {
            return new EducatorDialog(clone);
        }
    }
}
