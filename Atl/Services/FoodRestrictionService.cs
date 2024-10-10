using Atl.DTOs;
using Atl.DTOs.FoodRestriction;
using Atl.Infrastructure;
using Atl.Mappers;

namespace Atl.Services
{
    public class FoodRestrictionService : IFoodRestrictionService
    {
        private readonly IFoodRestrictionRepository _foodRestrictionRepo;
        private readonly IChildRepository _childRepo;

        public FoodRestrictionService(IFoodRestrictionRepository foodRestrictionRepo, IChildRepository childRepo)
        {
            _foodRestrictionRepo = foodRestrictionRepo;
            _childRepo = childRepo;
        }

        public async Task<IEnumerable<FoodRestrictionDto>> GetAllAsync()
        {
            var foodRestrictions = await _foodRestrictionRepo.GetAllAsync();
            return foodRestrictions.Select(s => s.ToFoodRestrictionDto());
        }

        public async Task<FoodRestrictionDto> GetByIdAsync(int id)
        {
            var foodRestriction = await _foodRestrictionRepo.GetByIdAsync(id);
            return foodRestriction?.ToFoodRestrictionDto();
        }

        public async Task<FoodRestrictionDto> CreateAsync(int childId, CreateFoodRestrictionDto foodRestrictionDto)
        {
            if (!await _childRepo.ChildExists(childId))
                throw new ArgumentException("Child does not exist");

            var foodRestrictionModel = foodRestrictionDto.ToFoodRestrictionFromCreateDto(childId);
            await _foodRestrictionRepo.CreateAsync(foodRestrictionModel);
            return foodRestrictionModel.ToFoodRestrictionDto();
        }

        public async Task<FoodRestrictionDto> UpdateAsync(int id, UpdateFoodRestrictionRequestDto updateDto)
        {
            var foodRestriction = await _foodRestrictionRepo.UpdateAsync(id, updateDto.ToFoodRestrictionFromUpdateDto(id));
            return foodRestriction?.ToFoodRestrictionDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var foodRestrictionModel = await _foodRestrictionRepo.DeleteAsync(id);
            return foodRestrictionModel != null;
        }
    }
}
