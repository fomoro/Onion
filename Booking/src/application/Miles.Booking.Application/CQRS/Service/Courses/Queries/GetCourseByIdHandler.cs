using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Courses.Queries;
using Miles.Booking.Domain.DTOs;
using Miles.Booking.Repository;

namespace Miles.Booking.Application.CQRS.Service.Courses.Queries
{
    public class GetCourseByIdHandler : IRequestHandler<GetCoursesByIdRequestQuery, CourseDto>
    {
        private readonly ILogger<GetCourseByIdHandler> _logger;
        private readonly ICoursesProvider _context;
        private readonly IMapper _mapper;

        public GetCourseByIdHandler(ICoursesProvider context, IMapper mapper, ILogger<GetCourseByIdHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CourseDto> Handle(GetCoursesByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var record = await _context.GetAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                var dto = _mapper.Map<CourseDto>(record);
                return dto;
            }
        }
    }
}
