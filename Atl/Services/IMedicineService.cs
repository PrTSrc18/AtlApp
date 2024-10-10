using Atl.DTOs.Child;
using Atl.DTOs.Medicine;
using Atl.DTOs;
using Atl.Domain;

namespace Atl.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineDto>> GetAllAsync();
        Task<MedicineDto> GetByIdAsync(int id);
        Task<MedicineDto> GetByName(string name);
        Task<List<Child>> GetChildrenByMedicineAsync(int medicineId);
        Task<MedicineDto> CreateAsync(int childId, CreateMedicineDto medicineDto);
        Task<MedicineDto> UpdateAsync(int id, UpdateMedicineRequestDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
