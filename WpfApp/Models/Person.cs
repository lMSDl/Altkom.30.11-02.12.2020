using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person : Entity, ICloneable
    {
        [JsonProperty(PropertyName = "Nazwisko")]
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
