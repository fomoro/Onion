using AutoMapper;
using MediatR;
using Miles.Booking.Domain.CQRS.Customers.Queries;
using Miles.Booking.Domain.DTOs;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Domain.Interfaces;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Queries
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        //private readonly ILogger<CreateCustomerHandler> _logger = null;
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
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
