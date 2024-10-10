using Atl.DTOs.Parent;
using Atl.Infrastructure;
using Atl.Mappers;

namespace Atl.Services
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepo;
        private readonly IChildRepository _childRepo;

        public ParentService(IParentRepository parentRepo, IChildRepository childRepo)
        {
            _parentRepo = parentRepo;
            _childRepo = childRepo;
        }

        public async Task<IEnumerable<ParentDto>> GetAllAsync()
        {
            var parents = await _parentRepo.GetAllAsync();
            return parents.Select(s => s.ToParentDto());
        }

        public async Task<ParentDto> GetByIdAsync(int id)
        {
            var parent = await _parentRepo.GetByIdAsync(id);
            return parent?.ToParentDto();
        }

        public async Task<ParentDto> CreateAsync(int childId, CreateParentDto parentDto)
        {
            if (!await _childRepo.ChildExists(childId))
                throw new ArgumentException("Child does not exist");

            var parentModel = parentDto.ToParentFromCreateDto(childId);
            await _parentRepo.CreateAsync(parentModel);
            return parentModel.ToParentDto();
        }

        public async Task<ParentDto> UpdateAsync(int id, UpdateParentRequestDto updateDto)
        {
            var parent = await _parentRepo.UpdateAsync(id, updateDto.ToParentFromUpdateDto(id));
            return parent?.ToParentDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parentModel = await _parentRepo.DeleteAsync(id);
            return parentModel != null;
        }
    }
}
