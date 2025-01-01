using InternetShopApp.Services.Interfaces;
using InternetShopApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var cartItems = await _cartItemService.GetAllAsync();
            return Ok(cartItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemById(int id)
        {
            var cartItem = await _cartItemService.GetByIdAsync(id);
            if (cartItem == null)
            {
                return NotFound($"CartItem with ID {id} not found.");
            }
            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] CartItem cartItem)
        {
            if (cartItem == null)
            {
                return BadRequest("CartItem cannot be null.");
            }

            await _cartItemService.AddAsync(cartItem);
            return CreatedAtAction(nameof(GetCartItemById), new { id = cartItem.Id }, cartItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, [FromBody] CartItem cartItem)
        {
            if (cartItem == null || cartItem.Id != id)
            {
                return BadRequest("Invalid CartItem data.");
            }

            var existingCartItem = await _cartItemService.GetByIdAsync(id);
            if (existingCartItem == null)
            {
                return NotFound($"CartItem with ID {id} not found.");
            }

            await _cartItemService.UpdateAsync(cartItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var existingCartItem = await _cartItemService.GetByIdAsync(id);
            if (existingCartItem == null)
            {
                return NotFound($"CartItem with ID {id} not found.");
            }

            await _cartItemService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("items-in-cart/{cartId}")]
        public async Task<IActionResult> GetCartItemsByCartId(int cartId)
        {
            var cartItems = await _cartItemService.GetCartItemsByCartIdAsync(cartId);
            if (!cartItems.Any())
            {
                return NotFound($"No CartItems found for Cart ID {cartId}.");
            }
            return Ok(cartItems);
        }
    }
}

