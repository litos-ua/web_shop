using InternetShopApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InternetShopApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")] // Только для администраторов
    public class AdminProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public AdminProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id:int}")] // GET: api/Product/{id}
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }

        [HttpPost] // POST: api/admin/Product
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")] // PUT: api/admin/Product/{id}
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            product.Id = id;
            await _productService.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id:int}")] // DELETE: api/admin/Product/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound($"Product with ID {id} not found.");

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}

