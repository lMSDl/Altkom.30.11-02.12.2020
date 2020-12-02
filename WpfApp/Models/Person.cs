using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Models.Validators;
using System.ComponentModel;

namespace Models
{
    [Validator(typeof(PersonValidator))]
    public abstract class Person : Entity, ICloneable, INotifyPropertyChanged
    {
        private string _lastName;

        [JsonProperty(PropertyName = "Nazwisko")]
        public string LastName { get => _lastName; set { _lastName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
            } }
        public string FirstName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
