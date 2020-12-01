﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student : ICloneable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int IndexNumber { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
