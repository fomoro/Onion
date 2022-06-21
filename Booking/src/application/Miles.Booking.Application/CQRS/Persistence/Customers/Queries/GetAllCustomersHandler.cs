using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Customers.Queries;
using Miles.Booking.Domain.DTOs;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Queries
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, CustomerDto>
    {
        private readonly ILogger<GetAllCustomersHandler> _logger;
        private readonly IRepositoryAsync<Customer> _context;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(IRepositoryAsync<Customer> context, IMapper mapper, ILogger<GetAllCustomersHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerDto> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var record = await _context.ListAsync();
            var customers = _mapper.Map<CustomerDto>(record);
            return customers;       
        }
    }
}
