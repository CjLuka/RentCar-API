using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<UserApp>
    {
        Task<UserApp> GetByEmailAsync(string email);
        Task<UserApp> GetUserByUsernameAsync(string userName);
    }
}
