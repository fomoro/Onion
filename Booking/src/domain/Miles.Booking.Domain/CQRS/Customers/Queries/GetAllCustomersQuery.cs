using MediatR;
using Miles.Booking.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.CQRS.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<CustomerDto>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
