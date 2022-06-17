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
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        //private readonly ILogger<CreateCustomerHandler> _logger = null;
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                record.Nombre = request.Nombre;
                record.Apellido = request.Apellido;
                record.Telefono = request.Telefono;
                record.Email = request.Email;
                record.Direccion = request.Direccion;
                request.FechaNacimiento = request.FechaNacimiento;
                await _repositoryAsync.UpdateAsync(record);
                return record.Id;
            }
        }
    }
}
