using Atl.DTOs.Allergy;
using Atl.DTOs;
using Atl.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Atl.Mappers;
using Atl.DTOs.Parent;
using Atl.Services;

namespace Atl.Controllers
{
    [Route("api/parent")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var parentsDto = await _parentService.GetAllAsync();
            return Ok(parentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var parentDto = await _parentService.GetByIdAsync(id);
            if (parentDto == null)
                return NotFound();

            return Ok(parentDto);
        }

        [HttpPost("{childId:int}")]
        public async Task<IActionResult> Create([FromRoute] int childId, CreateParentDto parentDto)
        {
            try
            {
                var createdParent = await _parentService.CreateAsync(childId, parentDto);
                return CreatedAtAction(nameof(GetById), new { id = createdParent.Id }, createdParent);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateParentRequestDto updateDto)
        {
            var parentDto = await _parentService.UpdateAsync(id, updateDto);
            if (parentDto == null)
                return NotFound("Parent not found");

            return Ok(parentDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _parentService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
