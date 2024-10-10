using Atl.DTOs.HealthProblem;

namespace Atl.Services
{
    public interface IHealthProblemService
    {
        Task<IEnumerable<HealthProblemDto>> GetAllAsync();
        Task<HealthProblemDto> GetByIdAsync(int id);
        Task<HealthProblemDto> CreateAsync(int childId, CreateHealthProblemDto healthProblemDto);
        Task<HealthProblemDto> UpdateAsync(int id, UpdateHealthProblemRequestDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
