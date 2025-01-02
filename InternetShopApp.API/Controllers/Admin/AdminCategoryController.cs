using InternetShopApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InternetShopApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")] // Только для администраторов
    public class AdminCategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")] // GET: api/Category/{id}
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost] // POST: api/admin/Category
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoryService.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")] // PUT: api/admin/Category/{id}
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != category.Id)
                return BadRequest("ID mismatch");

            await _categoryService.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id:int}")] // DELETE: api/admin/Category/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategory = await _categoryService.GetByIdAsync(id);
            if (existingCategory == null)
                return NotFound($"Category with ID {id} not found.");

            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

