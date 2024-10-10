using Atl.Domain;
using Atl.DTOs.Child;
using Atl.Infrastructure;
using Atl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Atl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildMedicineController : ControllerBase
    {

        private readonly IChildMedicineService _childMedicineService;
        private readonly IChildService _childService;
        private readonly IMedicineService _medicineService;
        private readonly DataBaseContext _context;

        public ChildMedicineController(IChildMedicineService childMedicineService, IChildService childService, IMedicineService medicineService, DataBaseContext context)
        {
            _childMedicineService = childMedicineService;
            _childService = childService;
            _medicineService = medicineService;
            _context = context;

        }
       

        [HttpGet("ChildByMedicine/{medicineId}")]

        public async Task<List<Child>> GetChildByMedicine([FromRoute] int medicineId)
        {
            var taskGetAll = await _childMedicineService.GetChildByMedicine(medicineId);

            return taskGetAll.ToList();

        }

        [HttpGet("MedicineByChild/{childId}")]

        public async Task<List<Medicine>> GetAll([FromRoute] int childId)
        {
            var taskGetAll = await _childMedicineService.GetMedicineByChild(childId);

            return taskGetAll.ToList();

        }

        [HttpPost]
        public async Task<IActionResult> AddChildMedicine(int childId, int medicineId)
        {
            var result = await _childMedicineService.CreateAsync(childId, medicineId);

            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Data);
        }

    }
}
