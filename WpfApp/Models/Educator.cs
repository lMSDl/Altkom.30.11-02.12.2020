using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Educator : Person
    {
        public string Specialization { get; set; }
        
        //public string FullName => string.Format("{0} {1}", FirstName, LastName);
        public string FullName => $"{FirstName} {LastName}";

    }
}
