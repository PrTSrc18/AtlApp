using Atl.DTOs;
using Atl.DTOs.Allergy;
namespace Atl.Services
{
    public interface IAllergyService
    {
        Task<IEnumerable<AllergyDto>> GetAllAsync();
        Task<AllergyDto> GetByIdAsync(int id);
        Task<AllergyDto> CreateAsync(int childId, CreateAllergyDto alergyDto);
        Task<AllergyDto> UpdateAsync(int id, UpdateAllergyRequestDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
