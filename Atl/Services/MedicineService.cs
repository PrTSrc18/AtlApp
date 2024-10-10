using Atl.DTOs.Child;
using Atl.DTOs.Medicine;
using Atl.DTOs;
using Atl.Infrastructure;
using Atl.Mappers;
using Atl.Domain;

namespace Atl.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepo;
        private readonly IChildRepository _childRepo;

        public MedicineService(IMedicineRepository medicineRepo, IChildRepository childRepo)
        {
            _medicineRepo = medicineRepo;
            _childRepo = childRepo;
        }

        public async Task<IEnumerable<MedicineDto>> GetAllAsync()
        {
            var medicines = await _medicineRepo.GetAllAsync();
            return medicines.Select(s => s.ToMedicineDto());
        }

        public async Task<MedicineDto> GetByIdAsync(int id)
        {
            var medicine = await _medicineRepo.GetByIdAsync(id);
            if (medicine == null)
                return null;

            return medicine.ToMedicineDto();
        }

        public async Task<List<Child>> GetChildrenByMedicineAsync(int medicineId)
        {
            var children = await _medicineRepo.GetChildrenByMedicine(medicineId);
            return children;
        }

        public async Task<MedicineDto> UpdateAsync(int id, UpdateMedicineRequestDto updateDto)
        {
            var medicine = await _medicineRepo.UpdateAsync(id, updateDto.ToMedicineFromUpdateDto(id));
            return medicine.ToMedicineDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medicineModel = await _medicineRepo.DeleteAsync(id);
            return medicineModel != null;
        }

        public async Task<MedicineDto> CreateAsync(int childId, CreateMedicineDto medicineDto)
        {
            if (!await _childRepo.ChildExists(childId))
                throw new ArgumentException("Child does not exist");

            var medicineModel = medicineDto.ToMedicineFromCreateDto(childId);
            await _medicineRepo.CreateAsync(medicineModel);
            return medicineModel.ToMedicineDto();
        }

        public async Task<MedicineDto> GetByName(string name)
        {
            var medicine = await _medicineRepo.GetByName(name);
            return medicine.ToMedicineDto();
        }
    }
}
