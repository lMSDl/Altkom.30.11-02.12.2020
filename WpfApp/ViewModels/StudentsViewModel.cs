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
    public class StudentsViewModel
    {
        public ObservableCollection<Student> Students { get; }
        public Student SelectedStudent { get; set; }
        public StudentsViewModel()
        {
            Students = new ObservableCollection<Student>()
            {
                new Student() { FirstName = "Ewa", LastName = "Ewowska", IndexNumber = 512312},
                new Student() { FirstName = "Roman", LastName = "Romanowski", IndexNumber = 827123 },
                new Student() { FirstName = "Tadeusz", LastName = "Tadeuszowski", IndexNumber = 992712 },
            };
            DeleteCommand = new CustomCommand(
                obj => Students.Remove(SelectedStudent),
                obj => SelectedStudent != null && Students.Contains(SelectedStudent)
                );
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand => new CustomCommand(obj => AddOrEdit(new Student()), obj => true);
        public ICommand EditCommand => new CustomCommand(obj => AddOrEdit(SelectedStudent), obj => SelectedStudent != null);

        public void AddOrEdit(Student student)
        {
            var clone = (Student)student.Clone();

            var dialog = new StudentDialog(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            Students.Remove(student);
            Students.Add(clone);
        }
    }
}
