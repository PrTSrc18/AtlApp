using Atl.Domain;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure
{
    public class ParentRepository : IParentRepository
    {
        private readonly DataBaseContext _context;

        public ParentRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Parent> CreateAsync(Parent parentModel)
        {
            await _context.Parents.AddAsync(parentModel);
            await _context.SaveChangesAsync();
            return parentModel;
        }

        public async Task<Parent?> DeleteAsync(int id)
        {
            var parentModel = await _context.Parents.FirstOrDefaultAsync(x => x.Id == id);

            if (parentModel == null)
                return null;

            _context.Parents.Remove(parentModel);
            await _context.SaveChangesAsync();

            return parentModel;
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            return await _context.Parents.ToListAsync();
        }

        public async Task<Parent?> GetByIdAsync(int id)
        {
            return await _context.Parents.FindAsync(id);
        }

        public async Task<Parent?> UpdateAsync(int id, Parent parentModel)
        {
            var existingParent = await _context.Parents.FindAsync(id);
            if (existingParent == null)
                return null;

            existingParent.NameMother = parentModel.NameMother;
            existingParent.PhoneNumberMother = parentModel.PhoneNumberMother;
            existingParent.AddressMother = parentModel.AddressMother;
            existingParent.PostalCodeMother = parentModel.PostalCodeMother;
            existingParent.JobMother = parentModel.JobMother;
            existingParent.WorkPlaceMother = parentModel.WorkPlaceMother;
            existingParent.NameFather = parentModel.NameFather;
            existingParent.PhoneNumberFather = parentModel.PhoneNumberFather;
            existingParent.AddressFather = parentModel.AddressFather;
            existingParent.PostalCodeFather = parentModel.PostalCodeFather;
            existingParent.JobFather = parentModel.JobFather;
            existingParent.WorkPlaceFather = parentModel.WorkPlaceFather;

            await _context.SaveChangesAsync();

            return existingParent;
        }
    }
}
