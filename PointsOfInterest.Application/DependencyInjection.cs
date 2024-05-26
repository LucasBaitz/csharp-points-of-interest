using Microsoft.Extensions.DependencyInjection;
using PointsOfInterest.Application.Interfaces;
using PointsOfInterest.Application.Services;

namespace PointsOfInterest.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IGpsService, GpsService>();

            return services;
        }
    }
}
