using Atl.Domain;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure 
{ 
    public class HealthProblemRepository : IHealthProblemRepository
    {
        private readonly DataBaseContext _context;

        public HealthProblemRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<HealthProblem> CreateAsync(HealthProblem healthProblemModel)
        {
            await _context.HealthProblems.AddAsync(healthProblemModel);
            await _context.SaveChangesAsync();
            return healthProblemModel;
        }

        public async Task<HealthProblem?> DeleteAsync(int id)
        {
            var healthProblemModel = await _context.HealthProblems.FirstOrDefaultAsync(x => x.Id == id);

            if (healthProblemModel == null)
                return null;

            _context.HealthProblems.Remove(healthProblemModel);
            await _context.SaveChangesAsync();

            return healthProblemModel;
        }

        public async Task<List<HealthProblem>> GetAllAsync()
        {
            return await _context.HealthProblems.ToListAsync();
        }

        public async Task<HealthProblem?> GetByIdAsync(int id)
        {
            return await _context.HealthProblems.FindAsync(id);
        }

        public async Task<HealthProblem?> UpdateAsync(int id, HealthProblem healthProblemModel)
        {
            var existingHealthProblem = await _context.HealthProblems.FindAsync(id);
            if (existingHealthProblem == null)
                return null;

            existingHealthProblem.Name = healthProblemModel.Name;

            await _context.SaveChangesAsync();

            return existingHealthProblem;
        }
    }
}
