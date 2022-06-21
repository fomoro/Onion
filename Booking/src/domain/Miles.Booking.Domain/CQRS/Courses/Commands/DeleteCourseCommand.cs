using MediatR;

namespace Miles.Booking.Domain.CQRS.Courses.Commands
{
    public record DeleteCourseCommand(int Id) : IRequest;
}
