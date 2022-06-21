using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Miles.Booking.Domain.CQRS.Courses.Commands;
using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Application.CQRS.Service.Courses.Commands
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ILogger<UpdateCourseHandler> _logger;
        private readonly ICoursesProvider _context;
        private readonly IMapper _mapper;

        public UpdateCourseHandler(ICoursesProvider context, IMapper mapper, ILogger<UpdateCourseHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            
            var record = await _context.GetAsync(request.Id);
            if (record == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                var item = _mapper.Map<Course>(request);
                var result = await _context.UpdateAsync(item.Id, item);                                
                return result;
            }
        }
    }
}
