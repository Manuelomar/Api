using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermitPequests.Application.Interfaces;
using PermitPequests.Infraestructure.Persistence.Context;
using PermitPequests.Infraestructure.Persistence.Repository;

namespace PermitPequests.Infraestructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbContext, ApplicationDbContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            return services;

        }
    }
}
