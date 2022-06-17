using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.CQRS.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
