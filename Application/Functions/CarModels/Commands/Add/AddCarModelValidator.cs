using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.CarModels.Commands.Add
{
    public class AddCarModelValidator : AbstractValidator<AddCarModelCommand>
    {
        public AddCarModelValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty();
            RuleFor(x => x.ModelName).NotEmpty();
        }
    }
}
