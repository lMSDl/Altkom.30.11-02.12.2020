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
    public class EducatorsViewModel
    {
        public ObservableCollection<Educator> Educators { get; }
        public Educator SelectedEducator { get; set; }
        public EducatorsViewModel()
        {
            Educators = new ObservableCollection<Educator>()
            {
                new Educator() { FirstName = "Ewa", LastName = "Ewowska", Specialization = "Gotowanie" },
                new Educator() { FirstName = "Roman", LastName = "Romanowski", Specialization = "Budownictwo" },
                new Educator() { FirstName = "Tadeusz", LastName = "Tadeuszowski", Specialization = "IT" },
            };
            
            DeleteCommand = new CustomCommand(
                obj => Educators.Remove(SelectedEducator),
                obj => SelectedEducator != null && Educators.Contains(SelectedEducator)
                );
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Educator()), obj => true);
        public ICommand EditCommand => new CustomCommand(obj => AddOrEdit(SelectedEducator), obj => SelectedEducator != null);

        public void AddOrEdit(Educator educator)
        {
            var clone = (Educator)educator.Clone();

            var dialog = new EducatorDialog(clone);
            if(dialog.ShowDialog() != true)
            {
                return;
            }

            Educators.Remove(educator);
            Educators.Add(clone);
        }
    }
}
