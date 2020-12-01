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
    public class EducatorsViewModel : PeopleViewModel
    {
        private IEducatorsService Service { get; } = new DbEducatorsService();

        public override ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Educator()), obj => true);


        protected override Window CreateAddEditDialog(Person clone)
        {
            return new EducatorDialog(clone);
        }

        protected override void Add(Person clone)
        {
            clone.Id = Service.Create((Educator)clone);
        }
        protected override void Update(int id, Person person)
        {
            Service.Update(id, (Educator)person);
        }

        protected override void Refresh()
        {
            People.Clear();
            foreach (var educator in Service.Read())
            {
                People.Add(educator);
            }
        }

        protected override void Delete(int id)
        {
            Service.Delete(id);
        }
    }
}
