using Atl.Data;
using Atl.Domain;
using Atl.DTOs.Child;

namespace Atl.Infrastructure
{
    public interface IChildRepository
    {
        Task<List<Child>> GetAllAsync(QueryObject query);
        Task<Child?> GetByIdAsync(int id);
        Task<Child?> GetByNameAsync(string name);
        Task<Child> CreateAsync(Child childModel);
        Task<Child?> UpdateAsync(int id, UpdateChildRequestDto childDto);
        Task<Child?> DeleteAsync(int id);
        Task<bool> ChildExists(int id);
    }
}
