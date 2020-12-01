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
        public ObservableCollection<Person> People { get; }
        public Person SelectedPerson { get; set; }
        public PeopleViewModel(IEnumerable<Person> initialPeople)
        {
            People = new ObservableCollection<Person>(initialPeople);

            DeleteCommand = new CustomCommand(
                obj => People.Remove(SelectedPerson),
                obj => SelectedPerson != null && People.Contains(SelectedPerson)
                );
        }

        public ICommand DeleteCommand { get; set; }
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

            People.Remove(person);
            People.Add(clone);
        }

        protected abstract Window CreateAddEditDialog(Person clone);
    }
}
