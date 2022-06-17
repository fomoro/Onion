using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.Interfaces
{
    public interface IRepositoryAsync<T>: IRepositoryBase<T> where T : class
    {
    }
}
