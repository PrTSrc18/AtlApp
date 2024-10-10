using Atl.Domain;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly DataBaseContext _context;

        public MedicineRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Medicine> CreateAsync(Medicine medicineModel)
        {
            await _context.Medicines.AddAsync(medicineModel);
            await _context.SaveChangesAsync();
            return medicineModel;
        }

        public async Task<Medicine?> DeleteAsync(int id)
        {
            var medicineModel = await _context.Medicines.FirstOrDefaultAsync(x => x.Id == id);

            if (medicineModel == null)
                return null;

            _context.Medicines.Remove(medicineModel);
            await _context.SaveChangesAsync();

            return medicineModel;
        }

        public async Task<List<Medicine>> GetAllAsync()
        {
            return await _context.Medicines.ToListAsync();
        }

        public async Task<Medicine?> GetByIdAsync(int id)
        {
            return await _context.Medicines.FindAsync(id);
        }

        public async Task<Medicine?> GetByName(string name)
        {
            return await _context.Medicines.FirstOrDefaultAsync(n => n.Name == name);
        }

        public async Task<List<Child?>> GetChildrenByMedicine(int medicineId)
        {
            //return await _context.ChildMedicines.Where(e => e.MedicineId == medicineId).Select(c => c.Child).ToListAsync();
            return null;
        }

        public async Task<Medicine?> UpdateAsync(int id, Medicine medicineModel)
        {
            var existingMedicine = await _context.Medicines.FindAsync(id);
            if (existingMedicine == null)
                return null;

            existingMedicine.Name = medicineModel.Name;

            await _context.SaveChangesAsync();

            return existingMedicine;
        }
    }
}
