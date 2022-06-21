using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.CQRS.Customers.Commands
{
    public record DeleteCustomerCommand(int Id) : IRequest;
}
