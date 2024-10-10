using Atl.DTOs;
using Atl.DTOs.Medicine;
using Atl.Domain;

namespace Atl.Mappers
{
    public static class MedicineMapper
    {
        public static MedicineDto ToMedicineDto(this Medicine MedicineModel)
        {
            return new MedicineDto
            {
                Id = MedicineModel.Id,
                Name = MedicineModel.Name
                
            };
        }
        public static Medicine ToMedicineFromCreateDto(this CreateMedicineDto medicineDto, int childId)
        {
            return new Medicine
            {
                Name = medicineDto.Name,
                
            };
        }
        public static Medicine ToMedicineFromUpdateDto(this UpdateMedicineRequestDto medicineDto, int childId)
        {
            return new Medicine
            {
                Name = medicineDto.Name,
                
            };
        }
    }
}
