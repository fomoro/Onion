using AutoMapper;
using MediatR;
using Miles.Booking.Domain.CQRS.Customers.Queries;
using Miles.Booking.Domain.DTOs;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Queries
{
    internal class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, CustomerDto>
    {
        //private readonly ILogger<CreateCustomerHandler> _logger = null;
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.ListAsync();
            var customers = _mapper.Map<CustomerDto>(record);
            return customers;       
        }
    }
}
