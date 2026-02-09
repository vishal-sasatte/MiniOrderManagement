using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniOrderManagement.Application.Orders.Commands.CreateOrder;
using MiniOrderManagement.Application.Orders.Queries.GetOrdersByCustomerId;

namespace MiniOrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var result = await _mediator.Send(
                new GetOrdersByCustomerIdQuery(customerId));

            return Ok(result);
        }

    }
}
