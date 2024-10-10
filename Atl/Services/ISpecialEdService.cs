using Atl.DTOs;
using Atl.DTOs.SpecialEd;

namespace Atl.Services
{
    public interface ISpecialEdService
    {
        Task<IEnumerable<SpecialEdDto>> GetAllAsync();
        Task<SpecialEdDto> GetByIdAsync(int id);
        Task<SpecialEdDto> CreateAsync(int childId, CreateSpecialEdDto specialEdDto);
        Task<SpecialEdDto> UpdateAsync(int id, UpdateSpecialEdRequestDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
