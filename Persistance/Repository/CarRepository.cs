using Application.Contracts.Persistance;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class CarRepository : AsyncRepository<Car>, ICarRepository
    {
        public CarRepository(RentCarDbContext context) : base(context)
        {

        }

        new public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars
                .Include(x => x.CarsModel)
                .ToListAsync();
        }

        //Pobranie dostępnych samochodów
        public async Task<List<Car>> GetAvaliableCars(DateTime startDate, DateTime endDate)
        {
            return await _context.Cars
                .Include(x => x.CarsModel)
                //.Where(car => _context.Rents.Any(rental => rental.Status == "Ready"))
                .Where(car => !_context.Rents.Any(rental => rental.CarId == car.Id &&
                    (startDate <= rental.DateTo && endDate >= rental.DateFrom)))
                .ToListAsync();
        }
    }
}
