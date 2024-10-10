using Atl.Domain;

namespace Atl.Infrastructure
{
    public interface IParentRepository
    {
        Task<List<Parent>> GetAllAsync();
        Task<Parent?> GetByIdAsync(int id);
        Task<Parent> CreateAsync(Parent parentModel);
        Task<Parent?> UpdateAsync(int id, Parent parentModel);
        Task<Parent?> DeleteAsync(int id);
    }
}
