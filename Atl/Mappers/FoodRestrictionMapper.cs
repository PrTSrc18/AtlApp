using Atl.DTOs.Child;
using Atl.DTOs;
using Atl.Domain;
using Atl.DTOs.FoodRestriction;


namespace Atl.Mappers
{
    public static class FoodRestrictionMapper
    {
        public static FoodRestrictionDto ToFoodRestrictionDto(this FoodRestriction foodRestrictionModel)
        {
            return new FoodRestrictionDto
            {
                Id = foodRestrictionModel.Id,
                Name = foodRestrictionModel.Name,
                
            };
        }
        public static FoodRestriction ToFoodRestrictionFromCreateDto(this CreateFoodRestrictionDto foodRestrictionDto, int childId)
        {
            return new FoodRestriction
            {
                Name = foodRestrictionDto.Name,
                
            };
        }
        public static FoodRestriction ToFoodRestrictionFromUpdateDto(this UpdateFoodRestrictionRequestDto foodRestrictionDto, int childId)
        {
            return new FoodRestriction
            {
                Name = foodRestrictionDto.Name,
                
            };
        }
    }
}
