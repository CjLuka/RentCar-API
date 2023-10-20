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
    public class RentRepository : AsyncRepository<Rent>, IRentRepository
    {
        public RentRepository(RentCarDbContext context) : base(context)
        {
        }

        //pobranie ofert dla konkretnego użytkownika
        public async Task<List<Rent>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Rents
                .Include(x => x.Car)
                .Where(x => x.UserAppId == userId)
                .ToListAsync();     
        }
    }
}
