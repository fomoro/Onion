using MediatR;
using Miles.Booking.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.CQRS.Courses.Queries
{
    public record GetCoursesByIdRequestQuery(int Id) : IRequest<CourseDto>;
}
