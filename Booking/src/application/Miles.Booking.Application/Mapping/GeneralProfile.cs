using AutoMapper;
using Miles.Booking.Domain.CQRS.Customers.Commands;
using Miles.Booking.Domain.DTOs;
using Miles.Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Customer, CustomerDto>();
            #endregion

            #region Commands
            CreateMap<CreateCustomerCommand, Customer>();
            #endregion
        }
    }
}
