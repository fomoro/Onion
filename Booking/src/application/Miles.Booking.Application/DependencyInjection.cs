using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly()); //Mediator
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); ///Automapper
            return services;
        }
    }
}
