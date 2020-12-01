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

namespace WpfApp.ViewModels
{
    public abstract class PeopleViewModel
    {
        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();
        public Person SelectedPerson { get; set; }
        public PeopleViewModel()
        {
            Refresh();
        }


        public ICommand DeleteCommand => new CustomCommand(obj => { Delete(SelectedPerson.Id); People.Remove(SelectedPerson); }, obj => SelectedPerson != null && People.Contains(SelectedPerson));
        public abstract ICommand AddCommand { get; }
        public ICommand EditCommand => new CustomCommand(obj => AddOrEdit(SelectedPerson), obj => SelectedPerson != null);



        public void AddOrEdit(Person person)
        {
            var clone = (Person)person.Clone();

            var dialog = CreateAddEditDialog(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if(clone.Id == 0)
            {
                Add(clone);
            }
            else
            {
                Update(clone.Id, clone);
                People.Remove(person);
            }
            People.Add(clone);
        }

        protected abstract void Delete(int id);
        protected abstract void Refresh();
        protected abstract void Update(int id, Person person);
        protected abstract void Add(Person clone);

        protected abstract Window CreateAddEditDialog(Person clone);
    }
}
