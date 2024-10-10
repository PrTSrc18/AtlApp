using Atl.DTOs;
using Atl.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Atl.Mappers;
using Atl.Services;
using Atl.DTOs.SpecialEd;


namespace Atl.Controllers
{
    [Route("api/specialEd")]
    [ApiController]
    public class SpecialEdController : ControllerBase
    {

        private readonly ISpecialEdService _specialEdService;

        public SpecialEdController(ISpecialEdService specialEdService)
        {
            _specialEdService = specialEdService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specialEdsDto = await _specialEdService.GetAllAsync();
            return Ok(specialEdsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var specialEdDto = await _specialEdService.GetByIdAsync(id);
            if (specialEdDto == null)
                return NotFound();

            return Ok(specialEdDto);
        }

        [HttpPost("{childId:int}")]
        public async Task<IActionResult> Create([FromRoute] int childId, CreateSpecialEdDto specialEdDto)
        {
            try
            {
                var createdSpecialEd = await _specialEdService.CreateAsync(childId, specialEdDto);
                return CreatedAtAction(nameof(GetById), new { id = createdSpecialEd.Id }, createdSpecialEd);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSpecialEdRequestDto updateDto)
        {
            var specialEdDto = await _specialEdService.UpdateAsync(id, updateDto);
            if (specialEdDto == null)
                return NotFound("Special Education record not found");

            return Ok(specialEdDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _specialEdService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
