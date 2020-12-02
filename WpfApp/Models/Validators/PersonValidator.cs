using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 15);
            RuleFor(x => x.LastName).Length(1, 15).NotNull().Must(x => x?.Contains("A") ?? true).OverridePropertyName("Nazwisko").WithMessage("Nie zawiera dużej litery A");
        }
    }
}
