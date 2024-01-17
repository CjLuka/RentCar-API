using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rents.Commands.RentCar
{
    public class RentCarValidator : AbstractValidator<RentCarCommand>
    {
        public RentCarValidator()
        {
            RuleFor(x => x.CarId).NotEmpty();

            RuleFor(x => x.DateFrom)
                .NotEmpty();

            RuleFor(x => x.DateTo).NotEmpty();

            RuleFor(x => x).Must(x => x.DateFrom <  x.DateTo);
            RuleFor(x => x).Must(x => x.DateFrom >  DateTime.Now);

        }
    }
}
