using Atl.DTOs.HealthProblem;
using Atl.Infrastructure;
using Atl.Mappers;

namespace Atl.Services
{
    public class HealthProblemService : IHealthProblemService
    {
        private readonly IHealthProblemRepository _healthProblemRepo;
        private readonly IChildRepository _childRepo;

        public HealthProblemService(IHealthProblemRepository healthProblemRepo, IChildRepository childRepo)
        {
            _healthProblemRepo = healthProblemRepo;
            _childRepo = childRepo;
        }

        public async Task<IEnumerable<HealthProblemDto>> GetAllAsync()
        {
            var healthProblems = await _healthProblemRepo.GetAllAsync();
            return healthProblems.Select(s => s.ToHealthProblemDto());
        }

        public async Task<HealthProblemDto> GetByIdAsync(int id)
        {
            var healthProblem = await _healthProblemRepo.GetByIdAsync(id);
            return healthProblem?.ToHealthProblemDto();
        }

        public async Task<HealthProblemDto> CreateAsync(int childId, CreateHealthProblemDto healthProblemDto)
        {
            if (!await _childRepo.ChildExists(childId))
                throw new ArgumentException("Child does not exist");

            var healthProblemModel = healthProblemDto.ToHealthProblemFromCreateDto(childId);
            await _healthProblemRepo.CreateAsync(healthProblemModel);
            return healthProblemModel.ToHealthProblemDto();
        }

        public async Task<HealthProblemDto> UpdateAsync(int id, UpdateHealthProblemRequestDto updateDto)
        {
            var healthProblem = await _healthProblemRepo.UpdateAsync(id, updateDto.ToHealthProblemFromUpdateDto(id));
            return healthProblem?.ToHealthProblemDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var healthProblemModel = await _healthProblemRepo.DeleteAsync(id);
            return healthProblemModel != null;
        }
    }
}
