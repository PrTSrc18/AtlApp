using Atl.Data;
using Atl.Domain;
using Atl.DTOs.Child;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure
{

    public class ChildRepository : IChildRepository
    {
        private readonly DataBaseContext _context;

        public ChildRepository(DataBaseContext context)
        {
            _context = context;
        }
        public Task<bool> ChildExists(int id)
        {
            return _context.Allergies.AnyAsync(c => c.Id == id);
        }

        public async Task<Child> CreateAsync(Child childModel)
        {
            await _context.Children.AddAsync(childModel);
            await _context.SaveChangesAsync();

            return childModel;
        }

        public async Task<Child?> DeleteAsync(int id)
        {
            var stockModel = await _context.Children.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
                return null;

            _context.Children.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Child>> GetAllAsync(QueryObject query)
        {
            var children = _context.Children.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.FirstName))
            {
                children = children.Where(c => c.FirstName.Contains(query.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(query.LastName))
            {
                children = children.Where(c => c.LastName.Contains(query.LastName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    children = query.IsDescending ? children.OrderByDescending(s => s.FirstName) : children.OrderBy(s => s.FirstName);
                }
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                {
                    children = query.IsDescending ? children.OrderByDescending(s => s.LastName) : children.OrderBy(s => s.LastName);
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await children.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Child?> GetByIdAsync(int id)
        {
            return await _context.Children
                .Include(a => a.Allergies)
                .Include(f => f.FoodRestrictions)
                .Include(s => s.SpecialEds)
                .Include(h => h.HealthProblems)
                .Include(p => p.Parents)              
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Child?> GetByNameAsync(string name)
        {
            return await _context.Children.FirstOrDefaultAsync(n => n.FirstName == name);
        }

        public async Task<Child?> UpdateAsync(int id, UpdateChildRequestDto childDto)
        {
            var existingChild = await _context.Children.FirstOrDefaultAsync(x => x.Id == id);

            if (existingChild == null)
                return null;

            existingChild.FirstName = childDto.FirstName;
            existingChild.LastName = childDto.LastName;

            await _context.SaveChangesAsync();

            return existingChild;
        }
    }
}
