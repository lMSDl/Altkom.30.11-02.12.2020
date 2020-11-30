using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class EducatorsViewModel
    {
        public ICollection<Educator> Educators { get; }
        public EducatorsViewModel()
        {
            Educators = new List<Educator>()
            {
                new Educator() { FirstName = "Ewa", LastName = "Ewowska", Specialization = "Gotowanie" },
                new Educator() { FirstName = "Roman", LastName = "Romanowski", Specialization = "Budownictwo" },
                new Educator() { FirstName = "Tadeusz", LastName = "Tadeuszowski", Specialization = "IT" },
            };
        }
    }
}
