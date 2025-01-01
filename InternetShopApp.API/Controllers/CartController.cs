using InternetShopApp.Services.Interfaces;
using InternetShopApp.Domain.Entities; 
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace InternetShopApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _cartService.GetAllAsync();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            var cart = await _cartService.GetByIdAsync(id);
            if (cart == null)
            {
                return NotFound($"Cart with ID {id} not found.");
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] Cart cart)
        {
            if (cart == null)
            {
                return BadRequest("Cart cannot be null.");
            }

            await _cartService.AddAsync(cart);
            return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, cart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] Cart cart)
        {
            if (cart == null || cart.Id != id)
            {
                return BadRequest("Invalid cart data.");
            }

            var existingCart = await _cartService.GetByIdAsync(id);
            if (existingCart == null)
            {
                return NotFound($"Cart with ID {id} not found.");
            }

            await _cartService.UpdateAsync(cart);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var existingCart = await _cartService.GetByIdAsync(id);
            if (existingCart == null)
            {
                return NotFound($"Cart with ID {id} not found.");
            }

            await _cartService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("find")]
        public async Task<IActionResult> FindCarts([FromBody] Expression<Func<Cart, bool>> predicate)
        {
            var carts = await _cartService.FindAsync(predicate);
            return Ok(carts);
        }

        // Get all carts containing a specified item
        [HttpGet("carts-by-product/{productId}")]
        public async Task<IActionResult> GetCartsByProduct(int productId)
        {
            var carts = await _cartService.GetCartsByProductIdAsync(productId);
            if (!carts.Any())
            {
                return NotFound($"No carts found with product ID {productId}."); //{"predicate": "cart => cart.IsActive == true"}
            }
            return Ok(carts);
        }
    }
}

