using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Customers.Commands;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Commands
{
    public class DeleteCustomerHandler : IRequest<int>
    {
        private readonly ILogger<DeleteCustomerHandler> _logger;
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteCustomerHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper, ILogger<DeleteCustomerHandler> logger)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _logger = logger;
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
