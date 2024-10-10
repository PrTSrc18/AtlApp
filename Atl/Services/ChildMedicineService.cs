using Atl.Domain;
using Atl.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Atl.Services
{
    public class ChildMedicineService : IChildMedicineService
    {
        private readonly IChildRepository _childRepo;
        private readonly IMedicineService _medicineService;
        private readonly IChildService _childService;
        private readonly DataBaseContext _context;

        public ChildMedicineService(DataBaseContext context, IChildRepository childRepo, IChildService childService, IMedicineService medicineService)
        {
            _childService = childService;
            _childService = childService;
            _context = context;
            _childRepo = childRepo;
        }
        public async Task<List<Child>> GetChildByMedicine(int medicineID)
        {
            return await _context.Children
                .Include(c => c.ChildMedicines)
                .Where(c => c.ChildMedicines.Any(m => m.Medicine.Id == medicineID))
                .ToListAsync();
        }

        public async Task<bool> ChildMedicineExists(int childId, int medicineId)
        {
            return await _context.ChildMedicines.AnyAsync(cm => cm.Child.Id == childId && cm.Medicine.Id == medicineId);
        }

        public async Task<List<Medicine>> GetMedicineByChild(int childId)
        {
            return await _context.Medicines
               .Include(c => c.ChildMedicines)
               .Where(c => c.ChildMedicines.Any(m => m.Child.Id == childId))
               .ToListAsync();
        }

        public async Task<ServiceResult<ChildMedicine>> CreateAsync( int childId, int medicineId)
        {
            var child = await _context.Children.FindAsync(childId);
            var medicine = await _context.Medicines.FindAsync(medicineId);

            if (child == null || medicine == null)
                return new ServiceResult<ChildMedicine>
                {
                    Success = false,
                    ErrorMessage = "Child or Medicine not found."
                };

            bool exists = await ChildMedicineExists(childId, medicineId);

            if (exists)
            {
                return new ServiceResult<ChildMedicine>
                {
                    Success = false,
                    ErrorMessage = "Record already in database."
                };
            }

            var childMedicineModel = new ChildMedicine
            {
                ChildId = childId,
                MedicineId = medicineId
            };

            await _context.ChildMedicines.AddAsync(childMedicineModel);
            await _context.SaveChangesAsync();

            return new ServiceResult<ChildMedicine>
            {
                Success = true,
                Data = childMedicineModel
            };          
        }       
    }
}
