using Atl.Domain;

namespace Atl.Infrastructure
{
    public interface ISpecialEdRepository
    {
        Task<List<SpecialEd>> GetAllAsync();
        Task<SpecialEd?> GetByIdAsync(int id);
        Task<SpecialEd> CreateAsync(SpecialEd SpecialEdModel);
        Task<SpecialEd?> UpdateAsync(int id, SpecialEd SpecialEdModel);
        Task<SpecialEd?> DeleteAsync(int id);
    }
}
