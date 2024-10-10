using Atl.Domain;

namespace Atl.Infrastructure
{ 
    public interface IFoodRestrictionRepository
    {
        Task<List<FoodRestriction>> GetAllAsync();
        Task<FoodRestriction?> GetByIdAsync(int id);
        Task<FoodRestriction> CreateAsync(FoodRestriction foodRestrictionModel);
        Task<FoodRestriction?> UpdateAsync(int id, FoodRestriction foodRestrictionModel);
        Task<FoodRestriction?> DeleteAsync(int id);
    }
}
