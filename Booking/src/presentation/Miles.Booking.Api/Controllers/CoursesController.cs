using Microsoft.AspNetCore.Mvc;
using Miles.Booking.Domain.CQRS.Courses.Commands;
using Miles.Booking.Domain.CQRS.Courses.Queries;

namespace Miles.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllCoursesQuery request = new GetAllCoursesQuery();            
            var results = await Mediator.Send(request);         
            if (results != null)
            {
                return Ok(results);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetCoursesByIdRequestQuery request = new GetCoursesByIdRequestQuery(id);
            var result = await Mediator.Send(request);                       
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCourseCommand command)
        {                        
            if (command == null)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(command);
            
            if (result.IsSuccess)
            {
                return Ok(result.Id);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCourseCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return NotFound();

        }
        
    }
}
