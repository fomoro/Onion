using AutoMapper;
using MediatR;
using Miles.Booking.Domain.CQRS.Customers.Commands;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Domain.Interfaces;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        //private readonly ILogger<CreateCustomerHandler> _logger = null;
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Customer>(request);
            var data = await _repositoryAsync.AddAsync(newRegister);
            return data.Id; 
            //throw new NotImplementedException();
        }
    }
}
