using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Courses.Commands;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;

namespace Miles.Booking.Application.CQRS.Service.Courses.Commands
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, (bool IsSuccess, int? Id)>
    {
        private readonly ILogger<CreateCourseHandler> _logger;
        private readonly ICoursesProvider _context;
        private readonly IMapper _mapper;

        public CreateCourseHandler(ICoursesProvider context, IMapper mapper, ILogger<CreateCourseHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, int? Id)> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {           
            var newRegister = _mapper.Map<Course>(request);            
            var result = await _context.AddAsync(newRegister);
            return result;
        }
    }
}
