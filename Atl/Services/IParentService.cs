using Atl.DTOs.Parent;

namespace Atl.Services
{
    public interface IParentService
    {
        Task<IEnumerable<ParentDto>> GetAllAsync();
        Task<ParentDto> GetByIdAsync(int id);
        Task<ParentDto> CreateAsync(int childId, CreateParentDto parentDto);
        Task<ParentDto> UpdateAsync(int id, UpdateParentRequestDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
