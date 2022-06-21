using MediatR;
using Miles.Booking.Domain.DTOs;

namespace Miles.Booking.Domain.CQRS.Courses.Queries
{
    public record GetAllCoursesQuery : IRequest<CourseDto>;
}
