using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.CQRS.Courses.Commands
{
    public class CreateCourseCommand : IRequest<(bool IsSuccess, int? Id)>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Uri { get; set; }
    }
}
