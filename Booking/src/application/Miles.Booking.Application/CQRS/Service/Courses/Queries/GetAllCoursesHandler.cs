using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Courses.Queries;
using Miles.Booking.Domain.DTOs;
using Miles.Booking.Repository;

namespace Miles.Booking.Application.CQRS.Service.Courses.Queries
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, CourseDto>
    {
        private readonly ILogger<GetAllCoursesHandler> _logger;
        private readonly ICoursesProvider _context;
        private readonly IMapper _mapper;

        public GetAllCoursesHandler(ICoursesProvider context, IMapper mapper, ILogger<GetAllCoursesHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CourseDto> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var results = await _context.GetAllAsync();            
            var customers = _mapper.Map<CourseDto>(results);
            return customers;
        }
    }
}
