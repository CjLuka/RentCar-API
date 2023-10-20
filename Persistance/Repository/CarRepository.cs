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
    }
}
