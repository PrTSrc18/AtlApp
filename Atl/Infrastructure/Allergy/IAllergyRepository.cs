using Atl.Domain;

namespace Atl.Infrastructure
{
    public interface IAllergyRepository
    {
        Task<List<Allergy>> GetAllAsync();
        Task<Allergy?> GetByIdAsync(int id);
        Task<Allergy> CreateAsync(Allergy allergyModel);
        Task<Allergy?> UpdateAsync(int id, Allergy allergyModel);
        Task<Allergy?> DeleteAsync(int id);
    }
}
