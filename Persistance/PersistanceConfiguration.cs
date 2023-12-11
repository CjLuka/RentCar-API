using Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Data;
using Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddDbContext<RentCarDbContext>(options =>
                options.UseSqlServer(connectionString ?? configuration.GetConnectionString("DeafultConnection")));

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarModelRepository, CarModelRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            return services;
        }
    }
}
