using Atl.Domain;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure
{
    public class SpecialEdRepository : ISpecialEdRepository
    {
        private readonly DataBaseContext _context;

        public SpecialEdRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<SpecialEd> CreateAsync(SpecialEd SpecialEdModel)
        {
            await _context.SpecialEds.AddAsync(SpecialEdModel);
            await _context.SaveChangesAsync();
            return SpecialEdModel;
        }

        public async Task<SpecialEd?> DeleteAsync(int id)
        {
            var SpecialEdModel = await _context.SpecialEds.FirstOrDefaultAsync(x => x.Id == id);

            if (SpecialEdModel == null)
                return null;

            _context.SpecialEds.Remove(SpecialEdModel);
            await _context.SaveChangesAsync();

            return SpecialEdModel;
        }

        public async Task<List<SpecialEd>> GetAllAsync()
        {
            return await _context.SpecialEds.ToListAsync();
        }

        public async Task<SpecialEd?> GetByIdAsync(int id)
        {
            return await _context.SpecialEds.FindAsync(id);
        }

        public async Task<SpecialEd?> UpdateAsync(int id, SpecialEd SpecialEdModel)
        {
            var existingSpecialEd = await _context.SpecialEds.FindAsync(id);
            if (existingSpecialEd == null)
                return null;

            existingSpecialEd.Name = SpecialEdModel.Name;

            await _context.SaveChangesAsync();

            return existingSpecialEd;
        }
    }
}
