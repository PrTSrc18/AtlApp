using Atl.DTOs;
using Atl.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Atl.Mappers;
using Atl.Services;
using Atl.DTOs.FoodRestriction;

namespace Atl.Controllers
{
    [Route("api/foodRestriction")]
    [ApiController]
    public class FoodRestrictionController : ControllerBase
    {
      
        private readonly IFoodRestrictionService _foodRestrictionService;

        public FoodRestrictionController(IFoodRestrictionService foodRestrictionService)
        {
            _foodRestrictionService = foodRestrictionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foodRestrictionDto = await _foodRestrictionService.GetAllAsync();
            return Ok(foodRestrictionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var foodRestrictionDto = await _foodRestrictionService.GetByIdAsync(id);
            if (foodRestrictionDto == null)
                return NotFound();

            return Ok(foodRestrictionDto);
        }

        [HttpPost("{childId:int}")]
        public async Task<IActionResult> Create([FromRoute] int childId, CreateFoodRestrictionDto foodRestrictionDto)
        {
            try
            {
                var createdFoodRestriction = await _foodRestrictionService.CreateAsync(childId, foodRestrictionDto);
                return CreatedAtAction(nameof(GetById), new { id = createdFoodRestriction.Id }, createdFoodRestriction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFoodRestrictionRequestDto updateDto)
        {
            var foodRestrictionDto = await _foodRestrictionService.UpdateAsync(id, updateDto);
            if (foodRestrictionDto == null)
                return NotFound("Food Restriction not found");

            return Ok(foodRestrictionDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _foodRestrictionService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

    }
}
