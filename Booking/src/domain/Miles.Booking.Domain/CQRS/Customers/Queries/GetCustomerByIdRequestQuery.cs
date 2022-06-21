using MediatR;
using Miles.Booking.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.CQRS.Customers.Queries
{
    public record GetCustomerByIdRequestQuery(int Id) : IRequest<CustomerDto>;
}
