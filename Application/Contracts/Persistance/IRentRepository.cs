using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IRentRepository : IAsyncRepository<Rent>
    {
        Task<List<Rent>> GetByUserIdAsync(Guid userId);
    }
}
