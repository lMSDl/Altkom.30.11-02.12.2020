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

namespace WpfApp.ViewModels
{
    public abstract class PeopleViewModel<TEntity, TService> where TEntity : Person where TService : ICrudService<TEntity>
    {
        protected abstract TService Service { get; }

        public ObservableCollection<TEntity> People { get; } = new ObservableCollection<TEntity>();
        public TEntity SelectedPerson { get; set; }
        public PeopleViewModel()
        {
            People.Clear();
            foreach (var person in Service.Read())
            {
                People.Add(person);
            }
        }

        public ICommand DeleteCommand => new CustomCommand(obj => { Service.Delete(SelectedPerson.Id); People.Remove(SelectedPerson); }, obj => SelectedPerson != null && People.Contains(SelectedPerson));
        public abstract ICommand AddCommand { get; }
        public ICommand EditCommand => new CustomCommand(obj => AddOrEdit(SelectedPerson), obj => SelectedPerson != null);

        public void AddOrEdit(TEntity person)
        {
            var clone = (TEntity)person.Clone();

            var dialog = CreateAddEditDialog(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if(clone.Id == 0)
            {
                clone.Id = Service.Create(clone);
            }
            else
            {
                Service.Update(clone.Id, clone);
                People.Remove(person);
            }
            People.Add(clone);
        }


        protected abstract Window CreateAddEditDialog(TEntity clone);
    }
}
