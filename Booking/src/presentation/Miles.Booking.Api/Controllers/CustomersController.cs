using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Miles.Booking.Domain.CQRS.Customers.Commands;
using Miles.Booking.Domain.CQRS.Customers.Queries;


namespace Miles.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllCustomersQuery request = new GetAllCustomersQuery();
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetCustomerByIdRequestQuery request = new GetCustomerByIdRequestQuery(id);
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteCustomerCommand request = new DeleteCustomerCommand(id);
            await Mediator.Send(request);
            return NoContent();            
        }
    }
}
