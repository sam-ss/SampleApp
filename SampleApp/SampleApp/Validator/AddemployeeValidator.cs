using FluentValidation;
using SampleApp.Models;
using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Validator
{
    public class AddemployeeValidator: AbstractValidator<Employee>
    { 
        public AddemployeeValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(3, 20).WithMessage("Passwords do not match");
            RuleFor(x => x.Designation).NotNull();
            RuleFor(x => x.Age).LessThan(100);
            RuleFor(x => x.Email).NotNull().EmailAddress();

        }
    }
}
