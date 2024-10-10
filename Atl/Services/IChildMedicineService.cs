using Atl.Domain;
using Atl.DTOs.Child;

namespace Atl.Services
{
    public interface IChildMedicineService
    {
        Task<List<Child>> GetChildByMedicine(int medicineId);
        Task<List<Medicine>> GetMedicineByChild(int childId);        
        Task<ServiceResult<ChildMedicine>> CreateAsync(int childId, int medicinId);
        Task<bool> ChildMedicineExists(int childId, int medicineId);


    }
}
