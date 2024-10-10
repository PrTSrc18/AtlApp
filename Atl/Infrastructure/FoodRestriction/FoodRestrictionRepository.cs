using Atl.Domain;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure
{
    public class FoodRestrictionRepository : IFoodRestrictionRepository
    {
        private readonly DataBaseContext _context;

        public FoodRestrictionRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<FoodRestriction> CreateAsync(FoodRestriction foodRestrictionModel)
        {
            await _context.FoodRestrictions.AddAsync(foodRestrictionModel);
            await _context.SaveChangesAsync();
            return foodRestrictionModel;
        }

        public async Task<FoodRestriction?> DeleteAsync(int id)
        {
            var foodRestrictionModel = await _context.FoodRestrictions.FirstOrDefaultAsync(x => x.Id == id);

            if (foodRestrictionModel == null)
                return null;
            _context.FoodRestrictions.Remove(foodRestrictionModel);
            await _context.SaveChangesAsync();

            return foodRestrictionModel;
        }

        public async Task<List<FoodRestriction>> GetAllAsync()
        {
            return await _context.FoodRestrictions.ToListAsync();
        }

        public async Task<FoodRestriction?> GetByIdAsync(int id)
        {
            return await _context.FoodRestrictions.FindAsync(id);
        }

        public async Task<FoodRestriction?> UpdateAsync(int id, FoodRestriction foodRestrictionModel)
        {
            var existingFoodRestriction = await _context.FoodRestrictions.FindAsync(id);
            if (existingFoodRestriction == null)
                return null;

            existingFoodRestriction.Name = foodRestrictionModel.Name;

            await _context.SaveChangesAsync();

            return existingFoodRestriction;
        }
    }
}
