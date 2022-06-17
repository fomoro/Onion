using AutoMapper;
using MediatR;
using Miles.Booking.Domain.CQRS.Customers.Commands;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Commands
{
    internal class DeleteCustomerHandler : IRequest<int>
    {
        //private readonly ILogger<CreateCustomerHandler> _logger = null;
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteCustomerHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                await _repositoryAsync.DeleteAsync(record);
                return record.Id;
            }
        }
    }
}
