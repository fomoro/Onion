using AutoMapper;
using MediatR;
using Miles.Booking.Domain.CQRS.Customers.Queries;
using Miles.Booking.Domain.DTOs;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;
using Microsoft.Extensions.Logging;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Queries
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdRequestQuery, CustomerDto>
    {
        private readonly ILogger<GetCustomerByIdHandler> _logger;
        private readonly IRepositoryAsync<Customer> _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(IRepositoryAsync<Customer> context, IMapper mapper, ILogger<GetCustomerByIdHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var record = await _context.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                var dto = _mapper.Map<CustomerDto>(record);
                return dto;
            }
        }
    }
}
