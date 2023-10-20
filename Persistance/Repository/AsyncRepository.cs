using Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly RentCarDbContext _context;
        public AsyncRepository(RentCarDbContext context)
        {
            _context= context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                            .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .FindAsync(id);
        }
    }
}
