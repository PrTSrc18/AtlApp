using Atl.Domain;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly DataBaseContext _context;

        public AllergyRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Allergy> CreateAsync(Allergy allergyModel)
        {
            await _context.Allergies.AddAsync(allergyModel);
            await _context.SaveChangesAsync();
            return allergyModel;
        }

        public async Task<Allergy?> DeleteAsync(int id)
        {
            var allergyModel = await _context.Allergies.FirstOrDefaultAsync(x => x.Id == id);

            if (allergyModel == null)
                return null;

            _context.Allergies.Remove(allergyModel);
            await _context.SaveChangesAsync();

            return allergyModel;
        }

        public async Task<List<Allergy>> GetAllAsync()
        {
            return await _context.Allergies.ToListAsync();
        }

        public async Task<Allergy?> GetByIdAsync(int id)
        {
            return await _context.Allergies.FindAsync(id);
        }

        public async Task<Allergy?> UpdateAsync(int id, Allergy allergyModel)
        {
            var existingAllergy = await _context.Allergies.FindAsync(id);
            if (existingAllergy == null)
                return null;

            existingAllergy.Name = allergyModel.Name;

            await _context.SaveChangesAsync();

            return existingAllergy;
        }
    }
}
