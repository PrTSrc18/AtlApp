using Atl.DTOs.Allergy;
using Atl.DTOs;
using Atl.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Atl.Mappers;
using Atl.DTOs.HealthProblem;
using Atl.Services;

namespace Atl.Controllers
{
    [Route("api/healthProblem")]
    [ApiController]
    public class HealthProblemController : ControllerBase
    {

        private readonly IHealthProblemService _healthProblemService;

        public HealthProblemController(IHealthProblemService healthProblemService)
        {
            _healthProblemService = healthProblemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var healthProblemsDto = await _healthProblemService.GetAllAsync();
            return Ok(healthProblemsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var healthProblemDto = await _healthProblemService.GetByIdAsync(id);
            if (healthProblemDto == null)
                return NotFound();

            return Ok(healthProblemDto);
        }

        [HttpPost("{childId:int}")]
        public async Task<IActionResult> Create([FromRoute] int childId, CreateHealthProblemDto healthProblemDto)
        {
            try
            {
                var createdHealthProblem = await _healthProblemService.CreateAsync(childId, healthProblemDto);
                return CreatedAtAction(nameof(GetById), new { id = createdHealthProblem.Id }, createdHealthProblem);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateHealthProblemRequestDto updateDto)
        {
            var healthProblemDto = await _healthProblemService.UpdateAsync(id, updateDto);
            if (healthProblemDto == null)
                return NotFound("Health Problem not found");

            return Ok(healthProblemDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _healthProblemService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
