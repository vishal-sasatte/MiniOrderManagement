using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniOrderManagement.Application.Commands.CreateCustomer;
using MiniOrderManagement.Application.Customers.Queries.GetCustomerById;

namespace MiniOrderManagement.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(result);
        }
    }

}


