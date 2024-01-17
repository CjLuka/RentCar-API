using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.Add
{
    public class AddCarValidator : AbstractValidator<AddCarCommand>
    {
        public AddCarValidator()
        {
            RuleFor(x => x.CarModelId).NotEmpty();

            RuleFor(x => x.Year)
                .NotEmpty()
                .GreaterThan(1886)
                .LessThan(2025)
                .WithMessage("Rok produkcji nie może być mniejszy niż 1886 oraz większy niż 2024");

        }
    }
}
