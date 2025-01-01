using InternetShopApp.Domain.Entities;
using InternetShopApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest("User ID mismatch.");

            await _userService.UpdateAsync(user);
            return NoContent();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }


        // GET: api/User/{id}/Orders
        [HttpGet("{id}/Orders")]
        public async Task<IActionResult> GetOrdersByUserId(int id)
        {
            var orders = await _userService.GetOrdersByUserIdAsync(id);
            if (orders == null || !orders.Any())
                return NotFound($"No orders found for User ID {id}.");

            return Ok(orders);
        }
    }
}
