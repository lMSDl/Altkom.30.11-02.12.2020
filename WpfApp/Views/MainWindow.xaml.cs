using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Page _students = new StudentsView();
        private readonly Page _educators = new EducatorsView();

        private void ToggleButton_Click_Educators(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(_educators);
            ToggleButton_Educators.IsChecked = true;
            ToggleButton_Students.IsChecked = false;
        }

        private void ToggleButton_Click_Students(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(_students);
            ToggleButton_Educators.IsChecked = false;
            ToggleButton_Students.IsChecked = true;
        }
    }
}
