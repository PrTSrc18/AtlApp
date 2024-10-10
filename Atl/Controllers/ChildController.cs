using Atl.Data;
using Atl.DTOs.Child;
using Atl.Infrastructure;
using Atl.Mappers;
using Atl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Atl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : Controller
    {
        private readonly IChildRepository _childRepo;
        private readonly IChildService _childService;
        private readonly DataBaseContext _context;

        public ChildController(DataBaseContext context, IChildRepository childRepo, IChildService childService )
        {        
            _childService = childService;
            _context = context;
            _childRepo = childRepo;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var taskGetAll = await _childService.GetAll(query);
            return Ok(taskGetAll);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
           var taskGetById = await _childService.GetById(id);
           return Ok(taskGetById);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChildDto childDto)
        {
            var childDtoResult = await _childService.CreateAsync(childDto);
            return CreatedAtAction(nameof(GetById), new { id = childDtoResult.Id }, childDtoResult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateChildRequestDto updateDto )
        {
            var childDtoResult = await _childService.UpdateAsync(id, updateDto);

            if (childDtoResult == null)
                return NotFound();

            return Ok(childDtoResult);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task< IActionResult> Delete([FromRoute] int id)
        {
            var taskDelete = await _childService.Delete(id);
            
            if(taskDelete == null)
                return NotFound();
            
            return NoContent();
        }
    }
}
