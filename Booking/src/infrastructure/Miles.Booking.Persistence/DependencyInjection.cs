using Microsoft.Extensions.DependencyInjection;
using Miles.Booking.Persistence.Context;
using Miles.Booking.Persistence.Repository;
using Miles.Booking.Repository;

namespace Miles.Booking.Persistence
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add Infraestructure Services
        /// </summary>
        /// <param name="services">List Service from startup</param>
        /// <param name="configuration">Configuration site</param>
        /// <returns>Updated service list</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));

            return services;
        }
    }
}
