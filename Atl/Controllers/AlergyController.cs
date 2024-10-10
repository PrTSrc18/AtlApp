using Atl.DTOs;
using Atl.DTOs.Allergy;
using Atl.DTOs.Allergy;
using Atl.Infrastructure;
using Atl.Mappers;
using Atl.Services;
using Microsoft.AspNetCore.Mvc;

namespace Atl.Controllers
{
    [Route("api/alergy")]
    [ApiController]
    public class AlergyController : ControllerBase
    {

        private readonly IAllergyService _allergyService;

        public AlergyController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allergyDto = await _allergyService.GetAllAsync();
            return Ok(allergyDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var allergyDto = await _allergyService.GetByIdAsync(id);
            if (allergyDto == null)
                return NotFound();

            return Ok(allergyDto);
        }

        [HttpPost("{childId:int}")]
        public async Task<IActionResult> Create([FromRoute] int childId, CreateAllergyDto alergyDto)
        {
            try
            {
                var createdAllergy = await _allergyService.CreateAsync(childId, alergyDto);
                return CreatedAtAction(nameof(GetById), new { id = createdAllergy.Id }, createdAllergy);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAllergyRequestDto updateDto)
        {
            var allergyDto = await _allergyService.UpdateAsync(id, updateDto);
            if (allergyDto == null)
                return NotFound("Alergy not found");

            return Ok(allergyDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _allergyService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
