using Atl.Domain;

namespace Atl.Infrastructure
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllAsync();
        Task<Medicine?> GetByIdAsync(int id);
        Task<Medicine?> GetByName(string name);
        Task<Medicine> CreateAsync(Medicine medicineModel);
        Task<Medicine?> UpdateAsync(int id, Medicine medicineModel);
        Task<Medicine?> DeleteAsync(int id);
        Task<List<Child?>> GetChildrenByMedicine(int medicineId);
    }
}
