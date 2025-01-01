using InternetShopApp.Services.Interfaces;
using InternetShopApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderItems = await _orderItemService.GetAllAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderItem = await _orderItemService.GetByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound(new { Message = $"OrderItem with ID {id} not found." });
            }
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOrderItem = await _orderItemService.AddOrderItemAsync(orderItem);
            return CreatedAtAction(nameof(GetById), new { id = createdOrderItem.Id }, createdOrderItem);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != orderItem.Id)
                return BadRequest();

            await _orderItemService.UpdateOrderItemAsync(orderItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }

    }

}
