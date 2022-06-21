using MediatR;

namespace Miles.Booking.Domain.CQRS.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Uri { get; set; }

    }
}
