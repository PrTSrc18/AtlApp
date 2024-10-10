using Atl.Domain;

namespace Atl.Infrastructure
{
    public interface IHealthProblemRepository
    {
        Task<List<HealthProblem>> GetAllAsync();
        Task<HealthProblem?> GetByIdAsync(int id);
        Task<HealthProblem> CreateAsync(HealthProblem healthProblemModel);
        Task<HealthProblem?> UpdateAsync(int id, HealthProblem healthProblemModel);
        Task<HealthProblem?> DeleteAsync(int id);
    }
}
