using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointsOfInterest.Domain.Core.Intefaces;
using PointsOfInterest.Infrastructure.Persistence;
using PointsOfInterest.Infrastructure.Repositories;

namespace PointsOfInterest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SqliteConnectionString")!;

            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlite(connectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();


            return services;
        }
    }
}