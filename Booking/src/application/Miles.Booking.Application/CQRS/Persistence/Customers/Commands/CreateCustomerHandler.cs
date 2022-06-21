using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Customers.Commands;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ILogger<CreateCustomerHandler> _logger;
        private readonly IRepositoryAsync<Customer> _context;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IRepositoryAsync<Customer> context, IMapper mapper, ILogger<CreateCustomerHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Customer>(request);
            await _context.AddAsync(newRegister);
            await _context.SaveChangesAsync(cancellationToken);
            return newRegister.Id; 
            //throw new NotImplementedException();
        }
    }
}
