using Atl.Domain;
using Atl.DTOs;
using Atl.DTOs.Allergy;
using Atl.DTOs.Child;
using Atl.DTOs.Medicine;
using Atl.Infrastructure;
using Atl.Mappers;
using Atl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atl.Controllers
{
    [Route("api/medicine")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicinesDto = await _medicineService.GetAllAsync();
            return Ok(medicinesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var medicineDto = await _medicineService.GetByIdAsync(id);
            if (medicineDto == null)
                return NotFound();

            return Ok(medicineDto);
        }

        [HttpGet("child/{medicineId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChildDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetChildrenByMedicine(int medicineId)
        {
            var children = await _medicineService.GetChildrenByMedicineAsync(medicineId);
            return Ok(children);
        }

        [HttpPost("{childId:Guid}")]
        public async Task<IActionResult> Create([FromRoute] int childId, CreateMedicineDto medicineDto)
        {
            try
            {
                var createdMedicine = await _medicineService.CreateAsync(childId, medicineDto);
                return CreatedAtAction(nameof(GetById), new { id = createdMedicine.Id }, createdMedicine);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMedicineRequestDto updateDto)
        {
            var medicineDto = await _medicineService.UpdateAsync(id, updateDto);
            if (medicineDto == null)
                return NotFound("Medicine not found");

            return Ok(medicineDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _medicineService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}