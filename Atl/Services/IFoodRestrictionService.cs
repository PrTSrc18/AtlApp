using Atl.DTOs;
using Atl.DTOs.FoodRestriction;

namespace Atl.Services
{
    public interface IFoodRestrictionService
    {
        Task<IEnumerable<FoodRestrictionDto>> GetAllAsync();
        Task<FoodRestrictionDto> GetByIdAsync(int id);
        Task<FoodRestrictionDto> CreateAsync(int childId, CreateFoodRestrictionDto foodRestrictionDto);
        Task<FoodRestrictionDto> UpdateAsync(int id, UpdateFoodRestrictionRequestDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
