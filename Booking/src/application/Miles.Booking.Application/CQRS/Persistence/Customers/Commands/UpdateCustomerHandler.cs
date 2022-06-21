using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Customers.Commands;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;

namespace Miles.Booking.Application.CQRS.Persistence.Customers.Commands
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ILogger<CreateCustomerHandler> _logger;
        private readonly IRepositoryAsync<Customer> _context;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(IRepositoryAsync<Customer> context, IMapper mapper, ILogger<CreateCustomerHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var record = await _context.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                /*record.Nombre = request.Nombre;
                record.Apellido = request.Apellido;
                record.Telefono = request.Telefono;
                record.Email = request.Email;
                record.Direccion = request.Direccion;
                request.FechaNacimiento = request.FechaNacimiento;*/
                //await _repositoryAsync.UpdateAsync(record);
                var item = _mapper.Map<Customer>(request);
                await _context.UpdateAsync(item);
                return record.Id;
            }
        }
    }
}
